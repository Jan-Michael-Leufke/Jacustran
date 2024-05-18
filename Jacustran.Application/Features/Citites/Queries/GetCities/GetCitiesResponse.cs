namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public class GetCitiesResponse : BaseResponse
{
    public IEnumerable<GetCitiesVm> Cities { get; set; } = new List<GetCitiesVm>();
    public int Count => Cities.Count();

    public GetCitiesResponse() { }
    public GetCitiesResponse(IEnumerable<GetCitiesVm> cities) => Cities = cities;
}
