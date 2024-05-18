using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.Products;

public interface IProductRepository : IAsyncRepository<Product, Guid>
{
}
