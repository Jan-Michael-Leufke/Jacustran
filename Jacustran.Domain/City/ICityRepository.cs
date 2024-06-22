using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.City;

public interface ICityRepository : IAsyncRepository<City, Guid>, ICityReadRepository 
{

}
