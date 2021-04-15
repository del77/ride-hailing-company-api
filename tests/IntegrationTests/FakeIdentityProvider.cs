using Application.Services;
using Core.Domain;

namespace IntegrationTests
{
    public class FakeIdentityProvider : IIdentityProvider
    {
        public static string TestCustomerId = "test_user";

        public string GetUserId() => TestCustomerId;
        public string GetRole() => UserRoles.Customer;
        public bool IsDriver() => false;
        public bool IsCustomer() => true;
    }
}