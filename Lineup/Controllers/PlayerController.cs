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
        private readonly IPlayerService _PlayerService;

        public PlayerController(IPlayerService playerService)
        {
            _PlayerService = playerService;
        }

        [HttpGet]
        public IActionResult AddPlayer(int teamId)
        {
            return View(new PlayerViewModel() { TeamId = teamId});
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player()
                {
                    Name = model.Name,
                    Age = model.Age,
                    TeamId = model.TeamId
                };
                await _PlayerService.AddPlayer(player);
                return RedirectToAction("TeamHome", "Team", new { id = model.TeamId });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id, int teamId)
        {
            Player player = await _PlayerService.GetPlayer(id);
            return View(new PlayerViewModel() { Name = player.Name, Age = player.Age, PlayerId = player.Id, TeamId = teamId });
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Id = model.PlayerId,
                    TeamId = model.TeamId
                };
                await _PlayerService.EditPlayer(player);
                return RedirectToAction("TeamHome", "Team", new { id = model.TeamId });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePlayer(int id, int teamId)
        {
            await _PlayerService.DeletePlayer(id);
            return RedirectToAction("TeamHome", "Team", new { id = teamId });
        }
    }
}
