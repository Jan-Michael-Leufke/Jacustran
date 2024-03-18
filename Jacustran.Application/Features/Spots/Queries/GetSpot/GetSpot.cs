namespace Jacustran.Application.Features.Spots.Queries.GetSpot;

public static class GetSpot
{
    public record GetSpotQuery(Guid Id) : IQuery<GetSpotVm>;


    internal class GetSpotQueryHandler : IQueryHandler<GetSpotQuery, GetSpotVm>
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IMapper _mapper;
        public GetSpotQueryHandler(ISpotRepository spotRepository, IMapper mapper) 
        {
            _spotRepository = spotRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetSpotVm>> Handle(GetSpotQuery request, CancellationToken token)
        {
            var spot = await _spotRepository.GetSpotWithTown(request.Id, token);

            if (spot is null) return SpotErrors.NotFound(request.Id).ToResult();
            
            return Result<GetSpotVm>.Success(_mapper.Map<GetSpotVm>(spot));
        }
    }

    public record GetSpotVm
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
        public GetSpotVm_TownDto? Town { get; set; }

    }

    public record GetSpotVm_TownDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Population { get; set;}
    }


}


