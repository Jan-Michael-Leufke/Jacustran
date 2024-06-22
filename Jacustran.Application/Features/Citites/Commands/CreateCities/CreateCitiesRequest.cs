using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Application.Features.Citites.Commands.CreateCities;

public class CreateCitiesRequest
{
    public const string Route = "api/CityCollections";

    [FromBody]
    public IEnumerable<CreateCitiesRequestDto> Cities { get; set; } = [];
}



public class CreateCitiesRequestDto : CityForManipulationDtoRequestBase
{
    public ICollection<CreateCities_CreateSpotsDto>? Spots { get; set; }

}



