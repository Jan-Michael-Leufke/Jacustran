

namespace Jacustran.Persistence.Repositories;

public class SpotRepository(JacustranDbContext context) : BaseRepository<Spot, Guid>(context), ISpotRepository
{
    public async Task<IEnumerable<Spot>> GetSpotsForCity(Guid cityId, CancellationToken token)
    {
       //if(await _context.Cities.AnyAsync(c => c.Id == cityId, token))
        return await _context.Spots.Where(s => s.Town.Id == cityId).ToListAsync(token);
    }

    public async Task<Spot?> GetSpotWithTown(Guid spotId, CancellationToken token)
    {
        return await _context.Spots.Include(s => s.Town).FirstOrDefaultAsync(s => s.Id == spotId, token);
    }

    public async Task<bool> IsCityIdValid(Guid cityId, CancellationToken token)
    {
        return await _context.Cities.AnyAsync(c => c.Id == cityId, token);
    }
}
