namespace Jacustran.Application.Features.Citites.Commands.CreateCities;

public record CreateCities_CreateSpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating StarRating { get; set; }
}
