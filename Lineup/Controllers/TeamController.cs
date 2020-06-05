using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lineup.ViewModels;
using Logics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Logics.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Lineup.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly IIdentityService IIdentityService;
        private readonly ITeamService ITeamService;
        private readonly IPlayerService IPlayerService;
        private readonly IFormationService IFormationService;

        public TeamController(IIdentityService iIdentityService, ITeamService iTeamService, IPlayerService iPlayerService, IFormationService iFormationService)
        {
            IIdentityService = iIdentityService;
            ITeamService = iTeamService;
            IPlayerService = iPlayerService;
            IFormationService = iFormationService;
        }

        [HttpGet]
        public async Task<IActionResult> AccountHome()
        {
            var userClaims = HttpContext.User;
            var user = await IIdentityService.GetUserAsync(userClaims.Identity.Name);
            var model = await ITeamService.GetAllTeams(user.Id);
            return View(new AccountHomeViewModel { Teams = model });
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamViewModel model)
        {
            var userClaims = HttpContext.User;
            var user = await IIdentityService.GetUserAsync(userClaims.Identity.Name);
            Team team = new Team()
            {
                UserId = user.Id,
                Name = model.TeamName
            };
            await ITeamService.AddTeam(team);
            return RedirectToAction(nameof(AccountHome));
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            await ITeamService.DeleteTeam(teamId);
            return RedirectToAction(nameof(AccountHome));
        }

        [HttpGet]
        public async Task<IActionResult> Team(int teamId)
        {
            var players = await IPlayerService.GetAllPlayers(teamId);
            var formations = await IFormationService.GetAllFormations(teamId);
            return View(new TeamViewModel { Players = players, Formations = formations });
        }
    }
}
