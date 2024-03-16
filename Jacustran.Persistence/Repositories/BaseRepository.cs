namespace Jacustran.Persistence.Repositories;

public class BaseRepository<T>(JacustranDbContext context) : IAsyncRepository<T> where T : EntityBase
{
    protected readonly JacustranDbContext _context = context;


    public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    
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


    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    //public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _context.SaveChangesAsync(cancellationToken);
    //}
}
