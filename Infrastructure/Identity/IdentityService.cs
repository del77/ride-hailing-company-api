using System;
using System.Threading.Tasks;
using Application.Services;
using Application.Users.Commands;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;

        public IdentityService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<string> RegisterAsync(RegisterAccount command)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = command.Username,
                Email = command.Email,
            };
            await _userManager.CreateAsync(user, command.Password);

            return user.Id.ToString();
        }
    }
}