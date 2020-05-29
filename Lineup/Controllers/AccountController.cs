using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lineup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Logics.Services;
using Logics.Entities;

namespace Lineup.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService IIdentityService;


        public AccountController(IIdentityService iIdentityService)
        {
            this.IIdentityService = iIdentityService;

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await IIdentityService.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var password = model.Password;
                var result = await IIdentityService.CreateAsync(user,password);

                if (result.Succeeded)
                {
                    await IIdentityService.PasswordSignInAsync(model.Email, model.Password, false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await IIdentityService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
    }
}
