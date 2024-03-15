using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Application.Contracts.Persistence;

public interface IProductRepository : IAsyncRepository<Product>
{
}
