namespace Jacustran.Domain.Cities;

public interface ICityRepository : IAsyncRepository<City>
{
    Task<City?> GetCityWithSpots(Guid id, CancellationToken token);
}
