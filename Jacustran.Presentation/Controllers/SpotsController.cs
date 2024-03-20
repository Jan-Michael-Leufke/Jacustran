using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;
using static Jacustran.Application.Features.Spots.Commands.CreateSpotForCity.CreateSpotForCity;
using static Jacustran.Application.Features.Spots.Queries.GetSpot.GetSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpots.GetSpots;

namespace Jacustran.Presentation.Controllers;

public class SpotsController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]
    [HttpHead]
    public async Task<IActionResult> GetSpots(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSpotsQuery(), cancellationToken);

        return Ok(result.Data);
    }

    
    [HttpGet("{spotId:guid}", Name = "GetSpotAction")]
    [HttpHead("{spotId:guid}")]
    public async Task<ActionResult<GetSpotVm>> GetSpot(Guid spotId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSpotQuery(spotId), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateSpot(CreateSpotRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(_mapper.Map<CreateSpotCommand>(request), cancellationToken);

        if (result.IsFailure) return FailureToProblemDetails(result);

        return CreatedAtRoute("GetSpotAction", new { spotId = result.Data } , result.Data);
    }

    [HttpPost("{cityId:guid}")]
    public async Task<ActionResult<Guid>> CreateSpotForCity(Guid cityId, CreateSpotForCityRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateSpotForCityCommand>(request);
        command.CityId = cityId;

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return FailureToProblemDetails(result);

        return CreatedAtRoute("GetSpotAction", new { spotId = result.Data }, result.Data);
    }
}
