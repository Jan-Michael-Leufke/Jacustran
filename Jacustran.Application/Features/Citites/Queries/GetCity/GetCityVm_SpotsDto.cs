namespace Jacustran.Application.Features.Citites.Queries.GetCity;

public class GetCityVm_SpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating Rating { get; set; }


}