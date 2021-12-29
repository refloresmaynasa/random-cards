using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PostgreSqlRepositoryAsync<T> : RepositoryBase<T>, ISqlRepositoryAsync<T> where T : class
    {
        private readonly SqlDbContext _dbContext;
        public PostgreSqlRepositoryAsync(SqlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
