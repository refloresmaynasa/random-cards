using Identity.Contexts;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();


        }
    }
}
