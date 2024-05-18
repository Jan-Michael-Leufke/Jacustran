namespace Jacustran.Application.Features.Citites.Queries.GetCity;

internal class GetCityQueryHandler : QueryHandlerBase<GetCityQuery, GetCityResponse>
{
    private readonly ICityRepository _cityrepository;
    public GetCityQueryHandler(IMapper mapper,
                               ICityRepository cityRepository) : base(mapper)
    {
        _cityrepository = cityRepository;
    }

    public override async Task<Result<GetCityResponse>> Handle(GetCityQuery query, CancellationToken token)
    {
        var city = await _cityrepository.GetCityWithSpots(query.CityId, token);

        return city is null ? CityErrors.NotFound(query.CityId).ToResult()
                            : Result<GetCityResponse>.Success(new GetCityResponse { City = _mapper.Map<GetCityVm>(city) });

    }
}


