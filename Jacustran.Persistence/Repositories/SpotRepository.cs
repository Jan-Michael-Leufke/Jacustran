
namespace Jacustran.Persistence.Repositories;

public class SpotRepository(JacustranDbContext context) : BaseRepository<Spot>(context), ISpotRepository
{
    public async Task<Spot?> GetSpotWithTown(Guid spotId, CancellationToken token)
    {
        return await _context.Spots.Include(s => s.Town).FirstOrDefaultAsync(s => s.Id == spotId, token);
    }

    public async Task<bool> IsCityIdValid(Guid cityId, CancellationToken token)
    {
        return await _context.Cities.AnyAsync(c => c.Id == cityId, token);
    }
}
