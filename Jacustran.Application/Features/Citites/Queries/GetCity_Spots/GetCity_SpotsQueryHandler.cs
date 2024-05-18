using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

internal class GetCity_Spots : QueryHandlerBase<GetCity_SpotsQuery, GetCity_SpotsResponse>
{
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    private readonly ISpotRepository _spotRepository;

    public GetCity_Spots(IMapper mapper,
                         IAsyncRepository<City, Guid> cityRepository,
                         ISpotRepository spotRepository)
        : base(mapper) 
        {
            _cityRepository = cityRepository;
            _spotRepository = spotRepository;
        }
    public override async Task<Result<GetCity_SpotsResponse>> Handle(GetCity_SpotsQuery query, CancellationToken cancellationToken)
    {
        if(!await _cityRepository.IsIdValid(query.CityId, cancellationToken))
            return Result<GetCity_SpotsResponse>.Failure(CityErrors.NotFound(query.CityId));

        var spots = await _spotRepository.GetSpotsForCity(query.CityId, cancellationToken);

        return Result<GetCity_SpotsResponse>.Success(new GetCity_SpotsResponse(_mapper.Map<IEnumerable<GetCity_SpotsVm>>(spots)));
    }
}
