using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public class GetCitiesQueryHandler : QueryHandlerBase<GetCitiesQuery, GetCitiesResponse> 
{
    private readonly IAsyncRepository<City, Guid> _asyncRepository;

    public GetCitiesQueryHandler(IMapper mapper, IAsyncRepository<City, Guid> asyncRepository) : base(mapper)  => _asyncRepository = asyncRepository;

    public override async Task<Result<GetCitiesResponse>> Handle(GetCitiesQuery query, CancellationToken token)
    {
        var getCitiesVms = _mapper.Map<IEnumerable<GetCitiesVm>>((await _asyncRepository.GetAllAsync(token)).OrderBy(c => c.Name));

        return Result<GetCitiesResponse>.Success(new GetCitiesResponse(getCitiesVms));

    }
}

