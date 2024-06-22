using Jacustran.SharedKernel.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace Jacustran.Persistence.Repositories;

public class CachedRepository<TEntity, TId> : IAsyncReadRepository<TEntity, TId>  
    where TEntity : AggregateRoot<TId> 
    where TId : struct  
{

    //protected readonly JacustranDbContext _context;

    protected readonly IAsyncRepository<TEntity, TId> _sourceRepository;
    protected readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    protected readonly ILogger<CachedRepository<TEntity, TId>> _logger;
    protected MemoryCacheEntryOptions _cacheOptions;

    public CachedRepository(IMemoryCache cache,
                            IAsyncRepository<TEntity, TId> sourceRepository, 
                            ILogger<CachedRepository<TEntity, TId>> logger)
    {
        _cache = cache;
        _sourceRepository = sourceRepository;
        _logger = logger;
        _cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(100));
    }

    public virtual Task<TEntity?> GetByIdAsync(TId id, CancellationToken token = default)
    {

        string key = $"{typeof(TEntity).Name}_{id}";

        _logger.LogInformation($"Checking cache for entity {key}");

        //_logger.LogInformation(_cache.TryGetValue(key, out Task<IReadOnlyList<TEntity>>? cachedValue) ?
        //        $"{key} found in cache" : $"{key} not found in cache");

        
        if(!_cache.TryGetValue(key, out Task<TEntity?>? cachedValue))
        {
            _logger.LogInformation($"{key} not found in cache");

            var dbCall = _sourceRepository.GetByIdAsync(id, token);

            _cache.Set(key, dbCall, _cacheOptions);

            return dbCall;            
        }
        
        _logger.LogInformation($"{key} found in cache");

        return cachedValue!;


    }

    public virtual Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken token = default)
    {
        string key = $"{typeof(TEntity).Name}_All";

        _logger.LogInformation($"Checking cache for entity {key}");
        _cache.TryGetValue(key, out Task<IReadOnlyList<TEntity>>? cachedValue);
        _logger.LogInformation(cachedValue is null ? $"{key} not found in cache" : $"{key} found in cache");


        var returnValue = _cache.GetOrCreate(key, entry =>
        {
            entry.SetOptions(_cacheOptions);

            return _sourceRepository.GetAllAsync(token);
        })!;

        return returnValue;
    }


    public Task<bool> IsIdValid(TId id, CancellationToken cancellationToken = default)
    {
        return _sourceRepository.IsIdValid(id, cancellationToken);
    }
    
    public Task<IReadOnlyList<TEntity>> GetByIdsAsync(IEnumerable<TId> Ids, CancellationToken cancellationToken = default)
    {
        //room for caching optimization here
        
        string key = $"{typeof(TEntity).Name}_{string.Join('_', Ids)}";

        return _cache.GetOrCreate(key, entry =>
        {
            entry.SetOptions(_cacheOptions);

            return _sourceRepository.GetByIdsAsync(Ids, cancellationToken);
        })!;

    }



    //public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _context.SaveChangesAsync(cancellationToken);
    //}
}
