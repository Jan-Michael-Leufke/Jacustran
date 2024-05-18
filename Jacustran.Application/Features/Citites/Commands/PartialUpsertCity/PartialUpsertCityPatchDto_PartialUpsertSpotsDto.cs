namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

public class PartialUpsertCityPatchDto_PartialUpsertSpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating StarRating { get; set; }
}