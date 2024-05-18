using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Spots.Queries.GetSpotCollection;

public static class GetSpotCollection
{
    public record GetSpotCollectionQuery(IEnumerable<Guid> SpotIds) : IQuery<IEnumerable<GetSpotCollectionVm>>;


    internal class GetSpotCollectionQueryHandler : IQueryHandler<GetSpotCollectionQuery, IEnumerable<GetSpotCollectionVm>>
    {
        private readonly IAsyncRepository<Spot, Guid> _spotRepository;
        private readonly IMapper _mapper;

        public GetSpotCollectionQueryHandler(IAsyncRepository<Spot, Guid> spotRepository, IMapper mapper)
        {
            _mapper = mapper;
            _spotRepository = spotRepository;
        }

        public async Task<Result<IEnumerable<GetSpotCollectionVm>>> Handle(GetSpotCollectionQuery request, CancellationToken token)
        {
            var spots = (await _spotRepository.GetByIdsAsync(request.SpotIds, token)).OrderBy(s => s.Name);

            if (!spots.Any()) return Result<IEnumerable<GetSpotCollectionVm>>.Failure(SpotErrors.NoneFound(request.SpotIds));

            if (spots.Count() != request.SpotIds.Count())
                return Result<IEnumerable<GetSpotCollectionVm>>.Failure(SpotErrors.SomeNotFound(request.SpotIds));

            return Result<IEnumerable<GetSpotCollectionVm>>.Success(_mapper.Map<IEnumerable<GetSpotCollectionVm>>(spots));
        }
    }

    

    public record GetSpotCollectionVm
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public StarRating Rating { get; init; }
    }
}