using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public static class IdentityDbContextSeeder
    {
        private const string SeedPassword = "zaq1@WSX";
        
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await AddRole(roleManager, UserRoles.Admin);
            await AddRole(roleManager, UserRoles.Customer);
            await AddRole(roleManager, UserRoles.Driver);

            await AddUser(userManager, "customer", "customer@email.com", new[] {UserRoles.Customer});
            await AddUser(userManager, "driver", "driver@email.com", new[] {UserRoles.Driver});
            await AddUser(userManager, "admin", "admin@email.com", new[] {UserRoles.Admin});
        }

        private static async Task AddRole(RoleManager<IdentityRole> roleManager, string role)
        {
            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private static async Task AddUser(UserManager<AppUser> userManager,
            string userName, string email, IEnumerable<string> roles)
        {
            if (await userManager.FindByNameAsync(userName) == null)
            {
                var user = new AppUser { UserName = userName, Email = email };
                await userManager.CreateAsync(user, SeedPassword);

                await userManager.AddToRolesAsync(user, roles);
            }
        }
    }
}