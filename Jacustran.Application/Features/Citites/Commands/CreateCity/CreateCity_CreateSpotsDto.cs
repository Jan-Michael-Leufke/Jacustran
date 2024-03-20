namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCity_CreateSpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating StarRating { get; set; }
}
