
using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Persistence.Repositories;

public class SpotRepository(JacustranDbContext context) : BaseRepository<Spot>(context), ISpotRepository
{
    
}
