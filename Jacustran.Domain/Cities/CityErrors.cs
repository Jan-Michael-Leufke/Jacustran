namespace Jacustran.Domain.Cities;

public static class CityErrors
{
    public static readonly Error FluentValidationError =
        new Error("City.FluentValidationError", "The Validation on Fluent-Validation didn´t check out.");

    public static Error NotFound(Guid cityGuid) => new Error("City.NotFound", $"City with id {cityGuid} was not found");


}
