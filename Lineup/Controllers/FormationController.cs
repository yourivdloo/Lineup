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
        private readonly IFormationService IFormationService;
        
        public FormationController(IFormationService iFormationService)
        {
            IFormationService = iFormationService;
        }

        [HttpGet]
        public IActionResult AddFormation()
        {
            return View();
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
