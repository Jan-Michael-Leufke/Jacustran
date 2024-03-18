namespace Jacustran.Application.Features.Citites.Queries.GetCity;

public record GetCityVm
{
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public bool IsImportantCity { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }   

    public ICollection<GetCityVm_SpotsDto> Spots { get; set; } = new List<GetCityVm_SpotsDto>();
}
