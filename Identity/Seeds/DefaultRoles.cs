using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Standard.ToString()));
        }
    }
}
