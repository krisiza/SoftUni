using GameZone.Contracts;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly GameZoneDbContext context;

        public GameService(GameZoneDbContext context)
        {
            this.context = context;
        }

        public async Task AddGameAsync(NewGameViewModel model, string userId)
        {
            DateTime date = DateTime.Now;

            DateTime.TryParseExact(model.ReleasedOn, ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            Game game = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ReleasedOn = date,
                ImageUrl = model.ImageUrl,
                PublischerId = userId,
                GenreId = model.GenreId
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task<bool> SaveGame(GameFormViewModel model)
        {
            var entity = await context.Games.FirstOrDefaultAsync(g => g.Id == model.Id);
            DateTime date = DateTime.Now;

            if(!DateTime.TryParseExact(model.ReleasedOn, ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return false;
            }

            if (entity != null)
            {
                entity.Title = model.Title;
                entity.ImageUrl = model.ImageUrl;
                entity.Description = model.Description;
                entity.ReleasedOn = date;
                entity.GenreId = model.GenreId;

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<GameFormViewModel> AddNewGameAsync()
        {
            var categories = await context.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();

            var model = new GameFormViewModel
            {
                Genres = categories
            };

            return model;
        }

        public async Task<IEnumerable<AllGameViewModel>> GetAllGamesAsync()
        {
            return await context.Games
                .Select(g => new AllGameViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleasedOn = g.ReleasedOn.ToString(ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = g.Publischer.UserName,
                    Genre = g.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<AllGameViewModel?> GetGameById(int id)
        {
            return context.Games
                .Select(g => new AllGameViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleasedOn = g.ReleasedOn.ToString(ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = g.Publischer.UserName,
                    Genre = g.Genre.Name
                })
                .FirstOrDefault(g => g.Id == id);
        }

        public async Task<GameFormViewModel?> GetGameFormById(int id)
        {
            var model = context.Games
                .Select(g => new GameFormViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleasedOn = g.ReleasedOn.ToString(ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = g.Publischer.UserName,
                    GenreId = g.GenreId
                })
                .FirstOrDefault(g => g.Id == id);

            model.Genres = await GetAllGeners();

            return model;
        }

        public async Task<GameDetailsViewModel?> GetGameDetailsById(int id)
        {
            return context.Games
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleasedOn = g.ReleasedOn.ToString(ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = g.Publischer.UserName,
                    Genre = g.Genre.Name
                })
                .FirstOrDefault(g => g.Id == id);
        }

        private async Task<List<GenreViewModel>>GetAllGeners()
        {
            return await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();
        }

        public async Task AddGameToGamerListAsync(AllGameViewModel model, string UserId)
        {
            if (!context.GamersGames.Any(g => g.GamerId == UserId && g.GameId == model.Id))
            {
                GamerGame gamerGame = new GamerGame()
                {
                    GamerId = UserId,
                    GameId = model.Id
                };

                await context.GamersGames.AddAsync(gamerGame);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllGameViewModel>> GetMyGames(string v)
        {
            return await context.GamersGames
                 .Where(gg => gg.Gamer.Id == v)
                 .Select(gg => new AllGameViewModel()
                 {
                     Id = gg.GameId,
                     Title = gg.Game.Title,
                     ImageUrl = gg.Game.ImageUrl,
                     Genre = gg.Game.Genre.Name,
                     Description = gg.Game.Description,
                     ReleasedOn = gg.Game.ReleasedOn.ToString(ValidationConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                     Publisher = gg.Game.Publischer.UserName
                 })
                 .ToListAsync();
        }

        public async Task<bool> RemoveGameToGamerListAsync(int gameId, string userId)
        {
            var foundModel = context.GamersGames.FirstOrDefault(g => g.GameId == gameId && g.GamerId == userId);

            if(foundModel == null) return false;

            context.GamersGames.Remove(foundModel);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteGame(int id)
        {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);
            var gamergames = context.GamersGames
                .Where(gg => gg.GameId == id)
                .ToListAsync();

            if(gamergames.Result.Any())
            {
                context.GamersGames.RemoveRange(gamergames.Result);
            }

            if(game != null)
            {
                context.Games.Remove(game);
            }

           await context.SaveChangesAsync();
        }
    }
}
