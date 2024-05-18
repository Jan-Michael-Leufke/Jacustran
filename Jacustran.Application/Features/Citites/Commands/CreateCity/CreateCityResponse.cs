namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityResponse(Guid cityId) : BaseResponse
{ 
    public Guid CityId { get; set; } = cityId;
}
