namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public class GetCitiesQueryHandler : IQueryHandler<GetCitiesQuery, IEnumerable<GetCitiesVm>>
{
    private readonly IAsyncRepository<City> _cityRepository;
    private readonly IMapper _mapper;
    
    public GetCitiesQueryHandler(IAsyncRepository<City> cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetCitiesVm>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var cityVms = _mapper.Map<IEnumerable<GetCitiesVm>>((await _cityRepository.GetAllAsync()).OrderBy(c => c.Name));

        return Result<IEnumerable<GetCitiesVm>>.Success(cityVms);
    }
}
