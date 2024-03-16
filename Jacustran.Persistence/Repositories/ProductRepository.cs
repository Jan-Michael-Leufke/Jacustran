namespace Jacustran.Persistence.Repositories;

public class ProductRepository(JacustranDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public Task<Product> AddAsync(Product entity)
    {       
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
