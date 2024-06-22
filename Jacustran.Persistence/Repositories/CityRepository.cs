using Jacustran.Application.Features.Citites.Queries.GetCity;
using Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

namespace Jacustran.Persistence.Repositories;

public class CityRepository(JacustranDbContext context) : BaseRepository<City, Guid>(context), ICityRepository
{
    public async Task<City?> GetCityWithSpots (Guid id, CancellationToken token, bool isNoTracking)
    {
        var query = _context.Cities.Include(c => c.Spots);
         
        if (isNoTracking) query.AsNoTracking();
            
        return await query.FirstOrDefaultAsync(c => c.Id == id, token);
    }


}
