using System.Linq;
using System.Security.Claims;
using Application.Services;
using Core.Domain;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Identity
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly HttpContext _httpContext;

        public IdentityProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string GetUserId()
        {
            return _httpContext.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public string GetRole() =>
            _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        public bool IsDriver() =>
            _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == UserRoles.Driver;

        public bool IsCustomer() =>
            _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == UserRoles.Customer;
    }
}