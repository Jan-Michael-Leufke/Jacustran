using Jacustran.SharedKernel.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Jacustran.Persistence.Repositories;

public class CityReadRepository : CachedRepository<City, Guid>, ICityReadRepository
{
    public CityReadRepository(IMemoryCache cache, 
                              ICityRepository sourceRepository, 
                              ILogger<CachedRepository<City, Guid>> logger) : base(cache, sourceRepository, logger)
    { }

    public Task<City?> GetCityWithSpots(Guid id, CancellationToken token, bool isNoTracking)
    {
        string key = $"{typeof(City).Name}_{id}";

        if(!_cache.TryGetValue(key, out Task<City?>? cachedValue))
        {
            _logger.LogInformation($"City with id {id} not found in cache");
            
            var dbCall = ((ICityRepository)_sourceRepository).GetCityWithSpots(id, token);

            _cache.Set(key, dbCall, _cacheOptions);

            return dbCall;
        }

        _logger.LogInformation($"City with id {id} found in cache");

        return cachedValue!;

        
    }

}
