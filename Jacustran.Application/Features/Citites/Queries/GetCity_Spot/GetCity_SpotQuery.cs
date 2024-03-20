namespace Jacustran.Application.Features.Citites.Queries.GetCity_Spot;

public record GetCity_SpotQuery(Guid CityId, Guid SpotId) : IQuery<GetCity_SpotVm> { }
