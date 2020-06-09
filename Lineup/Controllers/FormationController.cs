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
    public class FormationController : Controller
    {
        private readonly IFormationService _FormationService;
        private readonly IPlayerService _PlayerService;

        public FormationController(IFormationService formationService, IPlayerService playerService)
        {
            _FormationService = formationService;
            _PlayerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> AddFormation(int teamId)
        {
            List<Player> players = await _PlayerService.GetAllPlayers(teamId);
            return View(new AddFormationViewModel { Players = players });
        }

        [HttpPost]
        public IActionResult AddFormation(AddFormationViewModel model)
        {
            Formation formation = new Formation()
            {
                Name = model.Name,
                Players = model.PlayerPositions
            };
            return View();
        }

        [HttpGet]
        public IActionResult ViewFormation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteFormation()
        {
            return View();
        }
    }
}
