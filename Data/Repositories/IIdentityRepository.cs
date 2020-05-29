using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Dtos;
using System.Security.Claims;

namespace Data.Repositories
{
    public interface IIdentityRepository
    {
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe);

        Task SignInAsync(ApplicationUserDto user);

        Task<IdentityResult> CreateAsync(ApplicationUserDto user, string password);

        Task SignOutAsync();

        bool IsSignedIn(ClaimsPrincipal user);

    }
}
