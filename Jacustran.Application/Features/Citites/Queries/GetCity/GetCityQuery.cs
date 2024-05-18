namespace Jacustran.Application.Features.Citites.Queries.GetCity;


public class GetCityQuery : IQuery<GetCityResponse>
{
    public Guid CityId { get; set; }
}
