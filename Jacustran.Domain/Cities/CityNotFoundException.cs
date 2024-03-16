namespace Jacustran.Domain.Cities;
public class CityNotFoundException : NotFoundException
{
    public CityNotFoundException(Guid cityId) : base(cityId, $"City with id {cityId} was not found")
    {

    }
}
