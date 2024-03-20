namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

public record GetCityCollectionQuery(IEnumerable<Guid> CityIds) : IQuery<IEnumerable<GetCityCollectionVm>>
{

}
