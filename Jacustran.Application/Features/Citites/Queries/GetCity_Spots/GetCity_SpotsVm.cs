namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

public record GetCity_SpotsVm
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating Rating { get; set; }
}
