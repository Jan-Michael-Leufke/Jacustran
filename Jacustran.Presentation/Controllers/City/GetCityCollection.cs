using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using Jacustran.Presentation.Modelbinders;

namespace Jacustran.Presentation.Controllers.City;

public class GetCityCollection : AsyncEndpointBase.WithRequest<IEnumerable<Guid>>.WithResponse<GetCityCollectionResponse>
{
    public GetCityCollection(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpGet(GetCityCollectionRequest.Route, Name = "GetCityCollectionAction")]
    public override async Task<ActionResult<GetCityCollectionResponse>> HandleAsync(
               [ModelBinder(typeof(EnumerableArrayModelBinderType<Guid>))][FromRoute] IEnumerable<Guid> cityIds, CancellationToken token)
    {
        var result = await _sender.Send(new GetCityCollectionQuery(cityIds), token);

        return Ok(result.Data);
    }


}
