
namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

internal class GetCity_Spots : BaseQueryHandler<City> ,IQueryHandler<GetCity_SpotsQuery, IEnumerable<GetCity_SpotsVm>>
{
    private readonly ISpotRepository _spotRepository;

    public GetCity_Spots(IMapper mapper, 
                         IAsyncRepository<City> asyncRepository, 
                         ISpotRepository spotRepository) 
        : base(mapper, asyncRepository) => _spotRepository = spotRepository;
    

    public async Task<Result<IEnumerable<GetCity_SpotsVm>>> Handle(GetCity_SpotsQuery request, CancellationToken cancellationToken)
    {
        if(!await _asyncRepository.IsIdValid(request.CityId, cancellationToken))
            return Result<IEnumerable<GetCity_SpotsVm>>.Failure(CityErrors.NotFound(request.CityId));

        var spots = await _spotRepository.GetSpotsForCity(request.CityId, cancellationToken);

        return Result<IEnumerable<GetCity_SpotsVm>>.Success(_mapper.Map<IEnumerable<GetCity_SpotsVm>>(spots));
    }
}
