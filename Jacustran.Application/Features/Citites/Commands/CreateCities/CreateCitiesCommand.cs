using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Features.Citites.Commands.CreateCities;

public class CreateCitiesCommand : ICommand<CreateCitiesResponse>
{
    public IEnumerable<CreateCitiesCommandInnerDto> Cities { get; set; } = [];

}


public class CreateCitiesCommandInnerDto : CityForManipulationDtoBase
{
    public ICollection<CreateCities_CreateSpotsDto>? Spots { get; set; }

}
