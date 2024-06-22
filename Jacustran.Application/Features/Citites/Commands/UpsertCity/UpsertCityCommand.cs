namespace Jacustran.Application.Features.Citites.Commands.UpsertCity;

public class UpsertCityCommand : CityForManipulationDtoBase, ICommand<(Guid cityId, bool created)>
{
    public Guid CityId { get; set; }

    public ICollection<UpsertCity_UpsertSpotsDto>? Spots { get; set; }

}
