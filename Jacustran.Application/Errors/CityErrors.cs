using Jacustran.Domain.Errors;

namespace Jacustran.Application.Errors;

public static class CityErrors
{
    public static Error NotFound(Guid cityGuid) => new Error("City.NotFound", $"City with id {cityGuid} was not found");
}
