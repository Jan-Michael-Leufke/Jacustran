using Jacustran.SharedKernel.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Jacustran.Persistence.Repositories;

public class BaseRepository<TEntity, TId>(JacustranDbContext context) : IAsyncRepository<TEntity, TId> 
    where TEntity : AggregateRoot<TId>
    where TId : struct
{
    protected readonly JacustranDbContext _context = context;

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().FindAsync(id, token);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.Set<TEntity>().ToListAsync(token);
    }

    public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public async Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    public void Update(TEntity entity) => _context.Update(entity);
    
     
    public async Task<bool> IsIdValid(TId id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id.Equals(id), cancellationToken);
    }

    public void AddRange(IEnumerable<TEntity> entities) => _context.AddRange(entities);

    public async Task<IReadOnlyList<TEntity>> GetByIdsAsync(IEnumerable<TId> Ids, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(e => Ids.Contains(e.Id)).ToListAsync(cancellationToken);
    }



    //public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _context.SaveChangesAsync(cancellationToken);
    //}
}
