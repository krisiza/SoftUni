using GameZone.Contracts;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public async Task<IActionResult> All()
        {
            var model = await gameService.GetAllGamesAsync();
            return View(model);
        }

        public async Task<IActionResult> MyZone()
        {
            var model = await gameService.GetMyGames(GetUserId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await gameService.AddNewGameAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewGameViewModel model)
        {
            DateTime date;

            if (!DateTime.TryParse(model.ReleasedOn, out date ))
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Date is invalid.");
                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await gameService.AddGameAsync(model, GetUserId());

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToMyZone(int id)
        {
            var model = gameService.GetGameById(id);

            if (model.Result == null) 
                return RedirectToAction("All", "Game");

            await gameService.AddGameToGamerListAsync(model.Result, GetUserId());
            return RedirectToAction("MyZone", "Game");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GameFormViewModel? model = gameService.GetGameFormById(id).Result;

            if (model == null) 
                return BadRequest();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameFormViewModel model)
        {
            if(!await gameService.SaveGame(model))
                return BadRequest();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await gameService.GetGameDetailsById(id);

            if(model == null)
                return BadRequest();

            return View(model);
        }

        public async Task<IActionResult> StrikeOut(int id)
        {
            if(await gameService.RemoveGameToGamerListAsync(id, GetUserId()))
            {
                return RedirectToAction(nameof(MyZone));
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = gameService.GetGameFormById(id);
            return View(model.Result);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await gameService.DeleteGame(id);
            return RedirectToAction(nameof(All));
        }
    }
}
