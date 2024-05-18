using Jacustran.Application.Abstractions.Api;

namespace Jacustran.Application.Features.Citites.Queries.GetCity;

public class GetCityRequest : BaseRequest
{
    public const string Route = "api/Cities/{CityId:guid}";

    public Guid CityId { get; set; }
}
