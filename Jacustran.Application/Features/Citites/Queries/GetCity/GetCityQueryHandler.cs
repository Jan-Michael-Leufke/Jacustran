

namespace Jacustran.Application.Features.Citites.Queries.GetCity;

internal class GetCityQueryHandler : BaseCommandHandler<City>, IQueryHandler<GetCityQuery, GetCityVm>
{
    private readonly ICityRepository _cityrepository;   
    public GetCityQueryHandler(IUnitOfWork unitOfWork, 
                               IMapper mapper, 
                               IAsyncRepository<City> asyncRepository, 
                               ICityRepository cityRepository)
                             : base(unitOfWork, mapper, asyncRepository) 
    {
        _cityrepository = cityRepository;
    }

    public async Task<Result<GetCityVm>> Handle(GetCityQuery request, CancellationToken token)
    {
        var city = await _cityrepository.GetCityWithSpots(request.Id, token);

        return city is null ? CityErrors.NotFound(request.Id).ToResult()
                            : Result<GetCityVm>.Success(_mapper.Map<GetCityVm>(city));

    }
}
