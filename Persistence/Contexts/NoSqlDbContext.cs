using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class NoSqlDbContext : DbContext
    {
        private readonly IUtilityService _utilityService;
        private readonly ISessionService _sessionService;

        public NoSqlDbContext(DbContextOptions<NoSqlDbContext> options, IUtilityService utilityService, ISessionService sessionService) : base(options)
        {
            _utilityService = utilityService;
            _sessionService = sessionService;
        }

        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfig());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Card>())
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

        public static async Task CheckDatabaseAsync(DbContextOptions<NoSqlDbContext> options)
        {
            using var context = new NoSqlDbContext(options, null, null);
            //var _ = await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
