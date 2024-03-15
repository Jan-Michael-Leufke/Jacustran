using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

public class CitiesController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCitiesQuery(), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CreateCityCommand command, CancellationToken cancellationToken)
    {
        
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorDetails); 
    }
}
