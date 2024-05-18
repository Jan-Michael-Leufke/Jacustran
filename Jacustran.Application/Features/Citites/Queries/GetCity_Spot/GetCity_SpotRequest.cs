namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

public class GetCity_SpotRequest(Guid cityId, Guid spotId) : BaseRequest
{
    public const string Route = "api/cities/{cityId:guid}/spots/{spotId:guid}";

    public Guid CityId { get; set; } = cityId;
    public Guid SpotId { get; set; } = spotId;

    public GetCity_SpotRequest() : this(Guid.Empty, Guid.Empty) { }
}
