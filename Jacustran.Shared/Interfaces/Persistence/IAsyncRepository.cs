namespace Jacustran.SharedKernel.Interfaces.Persistence;

public interface IAsyncRepository<TEntity, TId> : IAsyncReadRepository<TEntity, TId>
    where TEntity : AggregateRoot<TId>
    where TId : struct
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);    
}
