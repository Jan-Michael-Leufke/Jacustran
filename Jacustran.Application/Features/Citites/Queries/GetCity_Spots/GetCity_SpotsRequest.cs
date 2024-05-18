using Jacustran.Application.Abstractions.Api;

namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

public class GetCity_SpotsRequest : BaseRequest
{
    public const string Route = "api/cities/{cityId:guid}/spots";

    public Guid CityId { get; set; }

    public GetCity_SpotsRequest() { }
    public GetCity_SpotsRequest(Guid cityId) =>  CityId = cityId;
    
}
