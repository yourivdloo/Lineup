using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logics.Entities;
using System.Security.Claims;

namespace Logics.Services
{
    public interface IIdentityService
    {
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe);

        Task SignInAsync(ApplicationUser user);

        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        Task SignOutAsync();

        bool IsSignedIn(ClaimsPrincipal user);
    }
}
