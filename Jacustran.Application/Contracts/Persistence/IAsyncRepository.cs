using Jacustran.Domain.Entity.Shared;
using System.Reflection.Metadata;

namespace Jacustran.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : EntityBase
{
    public Task<IReadOnlyList<T>> GetAllAsync();
    public Task<T> GetByIdAsync(Guid id);
    public Task<Guid> InsertAsync(T entity);
    public void Add(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);

    //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
