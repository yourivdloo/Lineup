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
        private readonly IIdentityService _IdentityService;
        private readonly ITeamService _TeamService;
        private readonly IPlayerService _PlayerService;
        private readonly IFormationService _FormationService;

        public TeamController(IIdentityService identityService, ITeamService teamService, IPlayerService playerService, IFormationService formationService)
        {
            _IdentityService = identityService;
            _TeamService = teamService;
            _PlayerService = playerService;
            _FormationService = formationService;
        }

        [HttpGet]
        public async Task<IActionResult> AccountHome()
        {
            var userClaims = HttpContext.User;
            var user = await _IdentityService.GetUserAsync(userClaims.Identity.Name);
            var teams = await _TeamService.GetAllTeams(user.Id);
            return View(new AccountHomeViewModel { Teams = teams });
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userClaims = HttpContext.User;
                var user = await _IdentityService.GetUserAsync(userClaims.Identity.Name);
                Team team = new Team()
                {
                    UserId = user.Id,
                    Name = model.Name
                };
                await _TeamService.AddTeam(team);
                return RedirectToAction(nameof(AccountHome));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _TeamService.DeleteTeam(id);
            return RedirectToAction(nameof(AccountHome));
        }

        [HttpGet]
        public async Task<IActionResult> TeamHome(int id)
        {
            var team = await _TeamService.GetTeam(id);
            var players = await _PlayerService.GetAllPlayers(id);
            var formations = await _FormationService.GetAllFormations(id);
            return View(new TeamHomeViewModel { Id = id, Players = players, Formations = formations, Name = team.Name  });
        }

        [HttpGet]
        public async Task<IActionResult> EditTeam(int id)
        {
            Team team = await _TeamService.GetTeam(id);
            return View(new TeamViewModel() { Name = team.Name, Id = team.Id});
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userClaims = HttpContext.User;
                var user = await _IdentityService.GetUserAsync(userClaims.Identity.Name);
                Team team = new Team()
                {
                    Name = model.Name,
                    Id = model.Id,
                    UserId = user.Id
                };
                await _TeamService.EditTeam(team);
                return RedirectToAction(nameof(AccountHome));
            }
            return View(model);
        }
    }
}
