namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

public class PartialUpsertCityPatchDto : CityForManipulationDtoBase
{
    public ICollection<PartialUpsertCityPatchDto_PartialUpsertSpotsDto>? Spots { get; set; }

}


public class PartialUpsertCityPatchDto_PartialUpsertSpotsDto : SpotForManipulationDtoBase
{
    public Guid Id { get; set; }
}