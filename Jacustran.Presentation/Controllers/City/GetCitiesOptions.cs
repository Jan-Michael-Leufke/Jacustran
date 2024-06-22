
using Jacustran.Application.Features.Citites.Queries.GetCitiesOptions;
using Microsoft.AspNetCore.Http;

namespace Jacustran.Presentation.Controllers.City;

public class GetCitiesOptions : AsyncEndpointBase.WithoutRequest.WithoutResponseAsIActionResult
{
    public GetCitiesOptions(ISender sender, IMapper mapper) : base(sender, mapper) { }


    [HttpOptions(GetCitiesOptionsRequest.Route)]
    public override IActionResult Handle()
    { 
         Response.Headers.Append("Allow", "GET,HEAD,POST,PUT,PATCH,OPTIONS");

         return Ok();
    }
}
