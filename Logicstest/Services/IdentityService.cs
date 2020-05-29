using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Logics.Entities;
using Logics.Mappers;
using System.Security.Claims;

namespace Logics.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly IIdentityRepository IIdentityRepository;

        public IdentityService(IIdentityRepository iIdentityRepository)
        {
            IIdentityRepository = iIdentityRepository;
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await IIdentityRepository.PasswordSignInAsync(email, password, rememberMe);
        }

        public async Task SignInAsync(ApplicationUser user)
        {
            var userDto = user.ToModel();
            await IIdentityRepository.SignInAsync(userDto);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var userDto = user.ToModel();
            return await IIdentityRepository.CreateAsync(userDto, password);
        }

        public async Task SignOutAsync()
        {
            await IIdentityRepository.SignOutAsync();
        }

        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return IIdentityRepository.IsSignedIn(user);
        }
    }
}
