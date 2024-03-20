namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

public record GetCity_SpotsQuery(Guid CityId) : IQuery<IEnumerable<GetCity_SpotsVm>> { }
