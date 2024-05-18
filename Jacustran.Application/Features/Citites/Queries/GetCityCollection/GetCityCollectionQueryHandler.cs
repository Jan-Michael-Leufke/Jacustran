using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

internal class GetCityCollectionQueryHandler : IQueryHandler<GetCityCollectionQuery, GetCityCollectionResponse>
{
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    private readonly IMapper _mapper;

    public GetCityCollectionQueryHandler(IAsyncRepository<City, Guid> cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Result<GetCityCollectionResponse>> Handle(GetCityCollectionQuery query, CancellationToken token)
    {
        var cities = await _cityRepository.GetByIdsAsync(query.CityIds, token);

        if (!cities.Any()) return Result<GetCityCollectionResponse>.Failure(CityErrors.NoneFound(query.CityIds));
        
        if(cities.Count() != query.CityIds.Count()) 
            return Result<GetCityCollectionResponse>.Failure(CityErrors.SomeNotFound(query.CityIds));

        return Result<GetCityCollectionResponse>.Success(new GetCityCollectionResponse(_mapper.Map<IEnumerable<GetCityCollectionVm>>(cities)));

    }
}
