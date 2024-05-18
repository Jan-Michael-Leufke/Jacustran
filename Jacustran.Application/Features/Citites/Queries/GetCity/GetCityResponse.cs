using Jacustran.Application.Abstractions.Api;

namespace Jacustran.Application.Features.Citites.Queries.GetCity;

public class GetCityResponse : BaseResponse
{
    public GetCityVm City { get; set; } = new GetCityVm();
}
