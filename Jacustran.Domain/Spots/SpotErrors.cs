namespace Jacustran.Domain.Spots;

public static class SpotErrors
{
    public static readonly Error ValidationError = new Error("Spot.ValidationError", "The Validation didn´t check out.");

    public static Error NotFound(Guid spotId) => new Error("Spot.NotFound", $"Spot with id {spotId} was not found");
}
