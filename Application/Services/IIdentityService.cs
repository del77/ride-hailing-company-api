using System.Threading.Tasks;
using Application.Users.Commands;

namespace Application.Services
{
    public interface IIdentityService
    {
        //Task<UserDto> GetAsync(Guid id);
        //Task<AuthDto> LoginAsync(SignIn command);
        Task<string> RegisterAsync(RegisterAccount command);
    }
}