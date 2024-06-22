using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.City;


public interface ICityReadRepository : IAsyncReadRepository<City, Guid> 
{
    Task<City?> GetCityWithSpots(Guid id, CancellationToken token, bool isNoTracking = false);
}

