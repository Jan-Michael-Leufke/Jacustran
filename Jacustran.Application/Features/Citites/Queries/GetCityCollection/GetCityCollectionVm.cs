namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

public record GetCityCollectionVm
{
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public bool IsImportantCity { get; set; }
    public string? Description { get; set; }
}
