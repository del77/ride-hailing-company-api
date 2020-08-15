using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Application.Users.Commands;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly UserManager<AppUser> _userManager;

        public IdentityService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenClaimsService tokenClaimsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }

        public async Task<string> AddUserAsync(string username, string email, string password,
            IEnumerable<string> roles)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = username,
                Email = email
            };
            await _userManager.CreateAsync(user, password);

            if (roles != null)
                await _userManager.AddToRolesAsync(user, roles);

            return user.Id;
        }

        public async Task<string> LoginAsync(LoginCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.Username);
            var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);
            if (result.Succeeded)
            {
                var token = await _tokenClaimsService.GetTokenAsync(command.Username);
                return token;
            }

            return null;
        }
    }
}