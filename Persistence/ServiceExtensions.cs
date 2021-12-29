using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static async void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("SqlConnection"),
                b => b.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName)));

            var cosmosOptionsBuilder = new DbContextOptionsBuilder<NoSqlDbContext>()
                .UseCosmos(
                configuration.GetValue<string>("CosmosDbSettings:AccountEndpoint"),
                configuration.GetValue<string>("CosmosDbSettings:AccountKey"),
                configuration.GetValue<string>("CosmosDbSettings:DatabaseName"));

            //services.AddDbContext<NoSqlDbContext>(options => options = cosmosOptionsBuilder);
            services.AddDbContext<NoSqlDbContext>(options =>
            options.UseCosmos(
                configuration.GetValue<string>("CosmosDbSettings:AccountEndpoint"),
                configuration.GetValue<string>("CosmosDbSettings:AccountKey"),
                configuration.GetValue<string>("CosmosDbSettings:DatabaseName"))
            );


            #region Repositories
            services.AddTransient(typeof(ISqlRepositoryAsync<>), typeof(PostgreSqlRepositoryAsync<>));
            services.AddTransient(typeof(INoSqlRepositoryAsync<>), typeof(CosmosRepositoryAsync<>));
            #endregion

            await NoSqlDbContext.CheckDatabaseAsync(cosmosOptionsBuilder.Options);
        }
    }
}
