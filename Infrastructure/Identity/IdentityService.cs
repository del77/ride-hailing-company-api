using System;
using System.Threading.Tasks;
using Application.Services;
using Application.Users.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;

        public IdentityService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenClaimsService tokenClaimsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }
        
        public async Task<string> RegisterAsync(RegisterAccountCommand command)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = command.Username,
                Email = command.Email,
            };
            await _userManager.CreateAsync(user, command.Password);

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