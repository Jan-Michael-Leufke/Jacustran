namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public class GetCitiesQueryHandler : BaseQueryHandler<City>, IQueryHandler<GetCitiesQuery, IEnumerable<GetCitiesVm>> 
{
    public GetCitiesQueryHandler(IMapper mapper, IAsyncRepository<City> asyncRepository) : base(mapper, asyncRepository) { }

    public async Task<Result<IEnumerable<GetCitiesVm>>> Handle(GetCitiesQuery request, CancellationToken token)
    {
        var getCitiesVms = _mapper.Map<IEnumerable<GetCitiesVm>>((await _asyncRepository.GetAllAsync(token)).OrderBy(c => c.Name));

        return Result<IEnumerable<GetCitiesVm>>.Success(getCitiesVms);
    }
}

