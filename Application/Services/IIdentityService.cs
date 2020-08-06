using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users.Commands;

namespace Application.Services
{
    public interface IIdentityService
    {
        Task<string> AddUserAsync(string username, string email, string password, IEnumerable<string> roles);
        Task<string> LoginAsync(LoginCommand command);
        Task<string> GetUserIdAsync();
    }
}