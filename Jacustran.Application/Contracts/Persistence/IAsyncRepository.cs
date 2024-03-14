using Jacustran.Domain.Shared;
using System.Reflection.Metadata;

namespace Jacustran.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : EntityBase
{
    public Task<IReadOnlyList<T>> GetAllAsync();
    public Task<T> GetByIdAsync(Guid id);
    public Task<T> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);

}
