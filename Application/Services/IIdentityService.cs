using System.Threading.Tasks;
using Application.Users.Commands;

namespace Application.Services
{
    public interface IIdentityService
    {
        Task<string> RegisterAsync(RegisterAccountCommand command);
        Task<string> LoginAsync(LoginCommand command);
    }
}