using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Dtos;
using System.Security.Claims;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly SignInManager<ApplicationUserDto> SignInManager;
        private readonly UserManager<ApplicationUserDto> UserManager;

        public IdentityRepository(SignInManager<ApplicationUserDto> signInManager, UserManager<ApplicationUserDto> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await SignInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task SignInAsync(ApplicationUserDto user)
        {
            await SignInManager.SignInAsync(user, isPersistent: false);
           
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUserDto user, string password)
        {
            return await UserManager.CreateAsync(user, password);
        }
        
        public async Task SignOutAsync()
        {
            await SignInManager.SignOutAsync();
        }

        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return SignInManager.IsSignedIn(user);
        }

        public async Task<ApplicationUserDto> GetUserAsync(string userName)
        {
            return await UserManager.FindByNameAsync(userName);
        }
    }
}
