using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

internal class GetCity_SpotQueryHandler : QueryHandlerBase<GetCity_SpotQuery, GetCity_SpotResponse> 
{
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    private readonly ISpotRepository _spotRepository;

    public GetCity_SpotQueryHandler(IMapper mapper,
                                    IAsyncRepository<City, Guid> cityRepository,
                                    ISpotRepository spotRepository)
        : base(mapper)
    {
        _cityRepository = cityRepository;
        _spotRepository = spotRepository;
    }

    public override async Task<Result<GetCity_SpotResponse>> Handle(GetCity_SpotQuery query, CancellationToken cancellationToken)
    {
        if(!await _cityRepository.IsIdValid(query.CityId, cancellationToken))
            return Result<GetCity_SpotResponse>.Failure(CityErrors.NotFound(query.CityId));

        var spot = await _spotRepository.GetByIdAsync(query.SpotId, cancellationToken);

        return spot is null ? Result<GetCity_SpotResponse>.Failure(SpotErrors.NotFound(query.SpotId))
                            : Result<GetCity_SpotResponse>.Success(new GetCity_SpotResponse(_mapper.Map<GetCity_SpotVm>(spot)));
    }
}
