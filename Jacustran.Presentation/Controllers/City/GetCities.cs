using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Presentation.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace Jacustran.Presentation.Controllers.City;

[Route(GetCitiesRequest.Route)]
public class GetCities : AsyncEndpointBase.WithoutRequest.WithResponse<GetCitiesResponse>
{
    public GetCities(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpGet]
    [HttpHead]
    //[SwaggerOperation]
    public override async Task<ActionResult<GetCitiesResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        throw new Exception("This is a test exception");

        return Ok((await _sender.Send(new GetCitiesQuery(), cancellationToken)).Data);
    }
}
 