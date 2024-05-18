using Jacustran.Application.Features.Citites.Queries.GetCity;

namespace Jacustran.Presentation.Controllers.City;


public class GetCity : AsyncEndpointBase.WithRequest<GetCityRequest>.WithResponse<GetCityResponse>
{
    public GetCity(ISender sender, IMapper mapper) : base(sender, mapper) { }


    [HttpGet(GetCityRequest.Route, Name = "GetCityAction")]
    [HttpHead(GetCityRequest.Route)]
    public async override Task<ActionResult<GetCityResponse>> HandleAsync([FromRoute]GetCityRequest request, CancellationToken token = default)
    {
        var result = await _sender.Send(new GetCityQuery { CityId = request.CityId }, token);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }
}
