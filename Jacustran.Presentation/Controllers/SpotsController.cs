using Jacustran.Application.Features.Spots.Queries.GetSpots;
using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;

namespace Jacustran.Presentation.Controllers;

public class SpotsController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]
    public async Task<IActionResult> GetSpots(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSpotsQuery(), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpot(CreateSpotRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(_mapper.Map<CreateSpotCommand>(request), cancellationToken);

        if(result.IsFailure) return FailureToProblemDetails(result);

        return Ok(result.Data);
    }
}
