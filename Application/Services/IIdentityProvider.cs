using System.Threading.Tasks;

namespace Application.Services
{
    public interface IIdentityProvider
    {
        string GetUserIdAsync();
        string GetRole();
        bool IsDriver();
        bool IsCustomer();
    }
}