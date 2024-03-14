using Jacustran.Domain.Entities;

namespace Jacustran.Application.Contracts.Persistence;

public interface IProductRepository : IAsyncRepository<Product>
{
}
