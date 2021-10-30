using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class CatalogDbContext : DbContext
    {
        private readonly IUtilityService _utilityService;

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IUtilityService utilityService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _utilityService = utilityService;
        }

        public DbSet<Catalog> Catalogs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModified = _utilityService.NowUtc;
                        entry.Entity.CreatedBy = ClaimsPrincipal.Current.Identity.Name;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _utilityService.NowUtc;
                        entry.Entity.CreatedBy = ClaimsPrincipal.Current.Identity.Name;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
