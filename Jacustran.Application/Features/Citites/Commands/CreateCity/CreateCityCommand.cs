using Jacustran.Application.Features.Shared.Spots;

namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommand : CityForManipulationDtoBase, ICommand<CreateCityResponse>
{
    public ICollection<CreateCity_CreateSpotsDto>? Spots { get; set; }
}


