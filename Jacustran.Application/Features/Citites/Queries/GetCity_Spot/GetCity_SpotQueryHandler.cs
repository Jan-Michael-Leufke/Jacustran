
namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

internal class GetCity_SpotQueryHandler : BaseQueryHandler<City> ,IQueryHandler<GetCity_SpotQuery, GetCity_SpotVm>
{
    private readonly ISpotRepository _spotRepository;

    public GetCity_SpotQueryHandler(IMapper mapper,
                                    IAsyncRepository<City> asyncRepository,
                                    ISpotRepository spotRepository)
        : base(mapper, asyncRepository) => _spotRepository = spotRepository;


    public async Task<Result<GetCity_SpotVm>> Handle(GetCity_SpotQuery request, CancellationToken cancellationToken)
    {
        if(!await _asyncRepository.IsIdValid(request.CityId, cancellationToken))
            return Result<GetCity_SpotVm>.Failure(CityErrors.NotFound(request.CityId));

        var spot = await _spotRepository.GetByIdAsync(request.SpotId, cancellationToken);

        return spot is null ? Result<GetCity_SpotVm>.Failure(SpotErrors.NotFound(request.SpotId))
                            : Result<GetCity_SpotVm>.Success(_mapper.Map<GetCity_SpotVm>(spot));
    }
}
