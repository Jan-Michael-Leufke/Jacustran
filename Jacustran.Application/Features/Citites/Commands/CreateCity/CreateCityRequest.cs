namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityRequest : CityForManipulationDtoRequestBase
{
    public const string Route = "api/cities";

    public ICollection<CreateCity_CreateSpotsDto>? Spots { get; set; }
}
