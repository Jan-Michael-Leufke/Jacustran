namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

public class GetCity_SpotResponse(GetCity_SpotVm getCity_SpotVm) : BaseResponse
{
    public GetCity_SpotVm Spot { get; set; } = getCity_SpotVm;
}
