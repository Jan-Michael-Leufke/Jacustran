namespace Jacustran.Domain.Cities;

public static class CitiesExceptions
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(Guid cityId) : base(cityId, $"City with id {cityId} was not found") { }


    }

}
