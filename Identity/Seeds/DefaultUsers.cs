using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager)
        {
            await AddAdminUser(userManager);
            await AddStandardUser(userManager);
        }

        private static async Task AddAdminUser(UserManager<AppUser> userManager)
        {
            var adminUser = new AppUser()
            {
                UserName = "userAdmin",
                Email = "userAdmin@mail.com",
                Name = "Administrator",
                LastName = "Last Name",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "Password999!");
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                await userManager.AddToRoleAsync(adminUser, Roles.Standard.ToString());
            }
        }

        private static async Task AddStandardUser(UserManager<AppUser> userManager)
        {
            var standardUser = new AppUser()
            {
                UserName = "userStandard",
                Email = "userStandard@mail.com",
                Name = "Standard",
                LastName = "Last Name",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(standardUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(standardUser, "Password999!");
                await userManager.AddToRoleAsync(standardUser, Roles.Standard.ToString());
            }
        }
    }
}
