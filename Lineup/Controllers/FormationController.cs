﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lineup.Controllers
{
    public class FormationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
