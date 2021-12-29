using Ardalis.Specification;

namespace Application.Interfaces
{
    public interface INoSqlRepositoryAsync<T> : IRepositoryBase<T> where T : class
    { }
}
