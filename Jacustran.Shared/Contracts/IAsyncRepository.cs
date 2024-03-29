﻿
namespace Jacustran.Shared.Contracts;

public interface IAsyncRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<Guid> InsertAsync(T entity);
    public void Add(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task<bool> IsIdValid(Guid id, CancellationToken cancellationToken);
    public void AddRange(IEnumerable<T> entities);
    public Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken);
    //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
