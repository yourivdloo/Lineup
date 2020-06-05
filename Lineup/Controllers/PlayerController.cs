using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lineup.ViewModels;
using Logics.Entities;
using Logics.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lineup.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly IPlayerService IPlayerService;

        public PlayerController(IPlayerService iPlayerService)
        {
            IPlayerService = iPlayerService;
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerViewModel model)
        {
            Player player = new Player()
            {
                Name = model.Name,
                Age = model.Age
            };
            await IPlayerService.AddPlayer(player);
            return RedirectToAction("Team", "Team");
        }

        [HttpGet]
        public IActionResult EditPlayer()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeletePlayer(int Id)
        {
            await IPlayerService.DeletePlayer(Id);
            return RedirectToAction("Team", "Team");
        }
    }
}
