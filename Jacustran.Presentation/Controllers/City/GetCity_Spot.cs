using Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

namespace Jacustran.Presentation.Controllers.City;

public class GetCity_Spot : AsyncEndpointBase.WithRequest<GetCity_SpotRequest>.WithResponse<GetCity_SpotResponse>
{
    public GetCity_Spot(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpGet(GetCity_SpotRequest.Route)]
    [HttpHead(GetCity_SpotRequest.Route)]
    public override async Task<ActionResult<GetCity_SpotResponse>> HandleAsync([FromRoute]GetCity_SpotRequest request, 
                                                                                CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(new GetCity_SpotQuery(request.CityId, request.SpotId), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }
}

