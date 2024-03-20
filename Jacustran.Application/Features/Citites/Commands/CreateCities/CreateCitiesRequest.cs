namespace Jacustran.Application.Features.Citites.Commands.CreateCities;

public record CreateCitiesRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public bool IsImportantCity { get; set; }
    public int Population { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<CreateCities_CreateSpotsDto>? Spots { get; set; } = new List<CreateCities_CreateSpotsDto>();

}
