using Ardalis.Specification;

namespace Application.Interfaces
{
    public interface ISqlRepositoryAsync<T> : IRepositoryBase<T> where T : class
    { }
}
