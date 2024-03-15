using Jacustran.Application.Contracts.Abstractions.MediatR;

namespace Jacustran.Application.Features.Citites.Queries.GetCities;

public record GetCitiesQuery : IQuery<IEnumerable<GetCitiesVm>>
{ }
