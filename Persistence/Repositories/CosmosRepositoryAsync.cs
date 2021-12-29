using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CosmosRepositoryAsync<T> : RepositoryBase<T>, INoSqlRepositoryAsync<T> where T : class
    {
        private readonly NoSqlDbContext _dbContext;
        public CosmosRepositoryAsync(NoSqlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
