
using Jacustran.Application.Features.Citites.Queries.GetCityCollectionOptions;
using Microsoft.AspNetCore.Http;

namespace Jacustran.Presentation.Controllers.City;

public class CityCollectionOptions : AsyncEndpointBase.WithoutRequest.WithoutResponseAsIActionResult
{
    public CityCollectionOptions(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpOptions(GetCityCollectionOptionsRequest.Route)]
    public override IActionResult Handle()
    {
        Response.Headers.Append("Allow", "GET,POST,OPTIONS");

        return Ok();
    }

}
