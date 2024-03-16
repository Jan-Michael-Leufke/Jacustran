
namespace Jacustran.Application.Features.Spots.Queries.GetSpots;

internal class GetSpotsQueryHandler : IQueryHandler<GetSpotsQuery, IEnumerable<GetSpotsVm>>
{
    private readonly IAsyncRepository<Spot> _spotRepository;
    private readonly IMapper _mapper;

    public GetSpotsQueryHandler(IAsyncRepository<Spot> spotRepository, IMapper mapper)
    {
        _spotRepository = spotRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetSpotsVm>>> Handle(GetSpotsQuery request, CancellationToken cancellationToken)
    {
        return Result<IEnumerable<GetSpotsVm>>.Success(
            _mapper.Map<IEnumerable<GetSpotsVm>>((await _spotRepository.GetAllAsync()).OrderBy(s => s.Name)));
    }
}
