
namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

internal class GetCityCollectionQueryHandler : IQueryHandler<GetCityCollectionQuery, IEnumerable<GetCityCollectionVm>>
{
    private readonly IAsyncRepository<City> _cityRepository;
    private readonly IMapper _mapper;

    public GetCityCollectionQueryHandler(IAsyncRepository<City> cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetCityCollectionVm>>> Handle(GetCityCollectionQuery request, CancellationToken token)
    {
        var cities = await _cityRepository.GetByIdsAsync(request.CityIds, token);

        //if (cities is null) return Result<IEnumerable<GetCityCollectionVm>>.Failure(CityErrors.NoneFound(request.CityIds));

        if (!cities.Any()) return Result<IEnumerable<GetCityCollectionVm>>.Failure(CityErrors.NoneFound(request.CityIds));
        
        if(cities.Count() != request.CityIds.Count()) 
            return Result<IEnumerable<GetCityCollectionVm>>.Failure(CityErrors.SomeNotFound(request.CityIds));

        var cityVms = _mapper.Map<IEnumerable<GetCityCollectionVm>>(cities);

        return Result<IEnumerable<GetCityCollectionVm>>.Success(cityVms);
    }
}
