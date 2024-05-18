using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.Categories;

public interface ICategoryRepository : IAsyncRepository<Category, Guid>
{
}
