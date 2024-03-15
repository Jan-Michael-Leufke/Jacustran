namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public record GetCitiesVm
{
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public bool IsImportantCity { get; set; }
    public string? Description { get; set; }
}
