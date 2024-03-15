using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
}
