using Jacustran.Application.Abstractions.Api;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Application.Features.Citites.Commands.UpsertCity;


public class UpsertCityRequest : BaseRequest
{
    public const string Route = "api/cities/{CityId:guid}";

    [FromRoute]
    public Guid CityId { get; set; }

    [FromBody]
    public UpsertCityRequestBody Body { get; set; } = null!;

}

public class UpsertCityRequestBody : CityForManipulationDtoBase
{
    public ICollection<UpsertCity_UpsertSpotsDto>? Spots { get; set; }
}
