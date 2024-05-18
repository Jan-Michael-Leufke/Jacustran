namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCity_CreateSpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public StarRating StarRating { get; set; }
}
