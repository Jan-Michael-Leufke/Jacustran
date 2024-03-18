using Jacustran.Application.Features.Citites.Queries.GetCity;

namespace Jacustran.Persistence.Repositories;

public class CityRepository(JacustranDbContext context) : BaseRepository<City>(context), ICityRepository
{
    public async Task<City?> GetCityWithSpots (Guid id, CancellationToken token)
    {
        return await _context.Cities.Include(c => c.Spots).FirstOrDefaultAsync(c => c.Id == id, token);
    }
}
