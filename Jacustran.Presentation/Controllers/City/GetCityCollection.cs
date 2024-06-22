using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using Jacustran.Application.Modelbinders;

namespace Jacustran.Presentation.Controllers.City;

public class GetCityCollection : AsyncEndpointBase.WithRequest<GetCityCollectionRequest>.WithResponse<GetCityCollectionResponse>
{
    public GetCityCollection(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpGet(GetCityCollectionRequest.Route, Name = "GetCityCollectionAction")]
    public override async Task<ActionResult<GetCityCollectionResponse>> HandleAsync(GetCityCollectionRequest request, CancellationToken token)
    {
        var result = await _sender.Send(new GetCityCollectionQuery(request.CityIds), token);

        return Ok(result.Data);
    }


}
