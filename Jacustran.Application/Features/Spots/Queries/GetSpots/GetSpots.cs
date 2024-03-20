namespace Jacustran.Application.Features.Spots.Queries.GetSpots;

public static class GetSpots
{
    public class GetSpotsQuery : IQuery<IEnumerable<GetSpotsVm>> { }

    internal class GetSpotsQueryHandler : IQueryHandler<GetSpotsQuery, IEnumerable<GetSpotsVm>>
    {
        private readonly IAsyncRepository<Spot> _spotRepository;
        private readonly IMapper _mapper;

        public GetSpotsQueryHandler(IAsyncRepository<Spot> spotRepository, IMapper mapper)
        {
            _mapper = mapper;
            _spotRepository = spotRepository;
        }

        public async Task<Result<IEnumerable<GetSpotsVm>>> Handle(GetSpotsQuery request, CancellationToken token)
        {
            return Result<IEnumerable<GetSpotsVm>>.Success(
                _mapper.Map<IEnumerable<GetSpotsVm>>((await _spotRepository.GetAllAsync(token)).OrderBy(s => s.Name)));
        }
    }

    public class GetSpotsVm
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
    }
}
