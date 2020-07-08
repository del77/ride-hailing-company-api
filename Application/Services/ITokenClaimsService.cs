using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}