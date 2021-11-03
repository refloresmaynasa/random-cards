using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class CatalogDbContext : DbContext
    {
        private readonly IUtilityService _utilityService;
        private readonly ISessionService _sessionService;

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IUtilityService utilityService, ISessionService sessionService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _utilityService = utilityService;
            _sessionService = sessionService;
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
                        entry.Entity.LastModifiedBy = _sessionService.CurrentUserName;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _utilityService.NowUtc;
                        entry.Entity.CreatedBy = _sessionService.CurrentUserName;
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
