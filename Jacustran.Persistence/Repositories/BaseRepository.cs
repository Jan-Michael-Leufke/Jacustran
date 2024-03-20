namespace Jacustran.Persistence.Repositories;

public class BaseRepository<T>(JacustranDbContext context) : IAsyncRepository<T> where T : EntityBase
{
    protected readonly JacustranDbContext _context = context;

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Set<T>().FindAsync(id, token);
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<T>().ToListAsync(token);
    }

    public void Add(T entity) => _context.Set<T>().Add(entity);

    public async Task<Guid> InsertAsync(T entity)
    {
        Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }


    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsIdValid(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AnyAsync(e => e.Id == id, cancellationToken);
    }

    public void AddRange(IEnumerable<T> entities) => _context.AddRange(entities);

    public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(e => Ids.Contains(e.Id)).ToListAsync(cancellationToken);
    }


    //public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _context.SaveChangesAsync(cancellationToken);
    //}
}
