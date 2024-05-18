using Jacustran.Application.Features.Citites.Queries.GetCity_Spots;
using MediatR;

namespace Jacustran.Presentation.Controllers.City;

public class GetCity_Spots : AsyncEndpointBase.WithRequest<GetCity_SpotsRequest>.WithResponse<GetCity_SpotsResponse>
{
    public GetCity_Spots(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpGet(GetCity_SpotsRequest.Route)]
    [HttpHead(GetCity_SpotsRequest.Route)]
    public override async Task<ActionResult<GetCity_SpotsResponse>> HandleAsync([FromRoute]GetCity_SpotsRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(new GetCity_SpotsQuery(request.CityId), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }
}

