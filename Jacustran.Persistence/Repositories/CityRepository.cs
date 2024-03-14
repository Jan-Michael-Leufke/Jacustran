namespace Jacustran.Persistence.Repositories;

public class CityRepository(JacustranDbContext context) : BaseRepository<City>(context), ICityRepository
{

}
