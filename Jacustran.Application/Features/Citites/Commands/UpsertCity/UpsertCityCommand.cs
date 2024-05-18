namespace Jacustran.Application.Features.Citites.Commands.UpdateCity;

public record UpsertCityCommand : ICommand<(Guid cityId, bool created)>
{
    public Guid CityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsImportantCity { get; set; }
    public int Population { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public ICollection<UpsertCityRequest_UpsertSpotsDto>? Spots { get; set; }

}
