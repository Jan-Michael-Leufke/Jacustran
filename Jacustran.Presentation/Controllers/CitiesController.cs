using AutoMapper;
using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

public class CitiesController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]
    public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCitiesQuery(), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(_mapper.Map<CreateCityCommand>(request), cancellationToken);

        ProblemDetails problemDetails = new()
        {
            
            Title = "An error occurred",
            Detail = "There was an error creating the city",
            Status = StatusCodes.Status500InternalServerError,
            Instance = HttpContext.Request.Path
        };

        return result.IsSuccess ? Ok(result.Data) : throw new Exception("server error"); 
    }
}
