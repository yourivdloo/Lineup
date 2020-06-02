using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lineup.ViewModels;
using Logics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lineup.Controllers
{
    public class TeamController : Controller
    {
        private readonly IIdentityService iIdentityService;
        private readonly ITeamService iTeamService;
        public TeamController(IIdentityService IIdentityService)
        {
            iIdentityService = IIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> AccountHome()
        {
            var userClaims = HttpContext.User;
            var user = await iIdentityService.GetUserAsync(userClaims.Identity.Name);
            var model = await iTeamService.GetTeams(user.Id);
            return View(new AccountHomeViewModel { Teams = model });
        }

        [HttpPost]
        public IActionResult AddTeam(AddTeamViewModel model)
        {
            
            iTeamService.AddTeam();
            return View();
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

    }
}
