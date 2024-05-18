namespace Jacustran.Domain.Spots;

public static class SpotErrors
{
    public static readonly Error ValidationError = new Error("Spot.ValidationError", "The Validation didn´t check out.");

    public static Error NotFound(Guid spotId) => new Error("Spot.NotFound", $"Spot with id {spotId} was not found");


    public static Error NoneFound(IEnumerable<Guid> spotIds) => new Error("Spot.NoneFound", $"No Spots were found with the " +
        $"following Ids: {string.Join(", ", spotIds)}");

    public static Error SomeNotFound(IEnumerable<Guid> spotIds) => new Error("Spot.SomeNotFound", $"There is" +
        $"a mismatch between the amount of ids and the amount of spots assotiated with them. Invalid Key: ${spotIds}");
}
