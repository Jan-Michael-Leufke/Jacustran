
namespace Jacustran.Domain.Cities;

public static class CityErrors
{
    public static readonly Error ValidationError = new Error("City.ValidationError", "The Validation didn´t check out.");

    public static Error NotFound(Guid cityGuid) => new Error("City.NotFound", $"City with id {cityGuid} was not found");


}
