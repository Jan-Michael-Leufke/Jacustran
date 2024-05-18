using Jacustran.Application.Abstractions.Api;

namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

public class GetCity_SpotsResponse : BaseResponse
{
    public IEnumerable<GetCity_SpotsVm> Spots { get; set; } = new List<GetCity_SpotsVm>();
    public int Count  => Spots.Count();


    public GetCity_SpotsResponse() { }
    public GetCity_SpotsResponse(IEnumerable<GetCity_SpotsVm> spots) => Spots = spots;

}
