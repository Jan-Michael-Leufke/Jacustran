using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

public class CitiesController(ISender sender, IMapper mapper, IMediator mediator) : ApiController(sender, mapper)
{
    [HttpGet]
    public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
    {
        return Ok((await _sender.Send(new GetCitiesQuery(), cancellationToken)).Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(_mapper.Map<CreateCityCommand>(request), cancellationToken);

        if(result.IsFailure) return FailureToProblemDetails(result);

        return Ok(result.Data);
    }
}
