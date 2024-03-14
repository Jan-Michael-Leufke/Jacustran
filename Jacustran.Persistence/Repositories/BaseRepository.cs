
namespace Jacustran.Persistence.Repositories;

public class BaseRepository<T>(JacustranDbContext context) : IAsyncRepository<T> where T : EntityBase
{
    protected readonly JacustranDbContext _context = context;


    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
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
}
