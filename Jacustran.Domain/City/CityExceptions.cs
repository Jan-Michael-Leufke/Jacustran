namespace Jacustran.Domain.City;

public static class CityExceptions
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(Guid cityId) : base(cityId, $"City with id {cityId} was not found") { }


    }

}


