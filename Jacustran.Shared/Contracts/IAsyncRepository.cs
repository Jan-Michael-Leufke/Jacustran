
namespace Jacustran.Shared.Contracts;

public interface IAsyncRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAllAsync();
    public Task<T> GetByIdAsync(Guid id);
    public Task<Guid> InsertAsync(T entity);
    public void Add(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    //Task SaveChangesAsync(CancellationToken cancellationToken);

    //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
