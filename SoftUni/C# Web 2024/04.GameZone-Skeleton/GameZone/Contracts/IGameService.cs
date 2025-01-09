using GameZone.ViewModels;

namespace GameZone.Contracts
{
    public interface IGameService
    {
        Task<IEnumerable<AllGameViewModel>> GetAllGamesAsync();
        Task<IEnumerable<AllGameViewModel>> GetMyGames(string v);
        Task<GameFormViewModel> AddNewGameAsync();
        Task AddGameAsync(NewGameViewModel model, string userId);
        Task<AllGameViewModel?> GetGameById(int id);
        Task<GameFormViewModel?> GetGameFormById(int id);
        Task<GameDetailsViewModel?> GetGameDetailsById(int id);
        Task AddGameToGamerListAsync(AllGameViewModel model, string UserId);
        Task<bool> RemoveGameToGamerListAsync(int gameId, string userId);
        Task<bool> SaveGame(GameFormViewModel model);
        Task DeleteGame(int id);
    }
}
