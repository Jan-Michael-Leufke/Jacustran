namespace Jacustran.SharedKernel.Interfaces.Persistence;

public interface IAsyncReadRepository<TEntity, TId> 
    where TEntity : AggregateRoot<TId> 
    where TId : struct
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetByIdsAsync(IEnumerable<TId> Ids, CancellationToken cancellationToken = default);
    Task<bool> IsIdValid(TId id, CancellationToken cancellationToken = default);
}
