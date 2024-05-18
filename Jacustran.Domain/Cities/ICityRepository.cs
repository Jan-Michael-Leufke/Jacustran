using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.Cities;

public interface ICityRepository : IAsyncRepository<City, Guid>
{
    Task<City?> GetCityWithSpots(Guid id, CancellationToken token);
}
