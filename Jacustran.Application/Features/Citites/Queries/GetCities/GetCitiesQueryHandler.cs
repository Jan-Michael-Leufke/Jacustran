using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public class GetCitiesQueryHandler : QueryHandlerBase<GetCitiesQuery, GetCitiesResponse> 
{
    private readonly ICityReadRepository _asyncReadRepository;

    public GetCitiesQueryHandler(IMapper mapper, ICityReadRepository asyncReadRepository) : base(mapper)  => 
        _asyncReadRepository = asyncReadRepository;

    public override async Task<Result<GetCitiesResponse>> Handle(GetCitiesQuery query, CancellationToken token)
    {
        var getCitiesVms = _mapper.Map<IEnumerable<GetCitiesVm>>((await _asyncReadRepository.GetAllAsync(token)).OrderBy(c => c.Name));

        return Result<GetCitiesResponse>.Success(new GetCitiesResponse(getCitiesVms));

    }
}

