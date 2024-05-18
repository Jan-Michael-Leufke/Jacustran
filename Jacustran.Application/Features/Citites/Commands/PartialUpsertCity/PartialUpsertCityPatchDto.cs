namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

public class PartialUpsertCityPatchDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsImportantCity { get; set; }
    public int Population { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<PartialUpsertCityPatchDto_PartialUpsertSpotsDto>? Spots { get; set; }

}
