namespace Application.Services
{
    public interface IIdentityProvider
    {
        string GetUserId();
        string GetRole();
        bool IsDriver();
        bool IsCustomer();
    }
}