using Jacustran.Presentation.Abstractions;
using Microsoft.AspNetCore.Http;
using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;
using static Jacustran.Application.Features.Spots.Commands.CreateSpotForCity.CreateSpotForCity;
using static Jacustran.Application.Features.Spots.Commands.PartialUpsertSpot.PartialUpsertSpot;
using static Jacustran.Application.Features.Spots.Commands.UpdateSpot.UpsertSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpot.GetSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpots.GetSpots;

namespace Jacustran.Presentation.Controllers;

[Route("api/Spots")]
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

        return CreatedAtRoute("GetSpotAction", new { spotId = result.Data }, result.Data);
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

    [HttpPut("{spotId:guid}")]
    public async Task<IActionResult> UpsertSpot(Guid spotId, UpsertSpotRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpsertSpotCommand>(request);
        command.SpotId = spotId;

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return FailureToProblemDetailsAsIActionResult(result);

        return result.Data.created ?
            CreatedAtRoute("GetSpotAction", new { result.Data.spotId }, result.Data .spotId) : NoContent();
    }


    [HttpPatch("{spotId:guid}")]
    public async Task<IActionResult> PartialUpdateSpot(Guid spotId, 
        JsonPatchDocument<PartialUpsertSpotPatchDto> patchDocument, 
        CancellationToken cancellationToken)
    {
        var command = new PartialUpsertSpotCommand { SpotId = spotId, PatchDocument = patchDocument };

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return FailureToProblemDetailsAsIActionResult(result);

        return result.Data.created ? 
            CreatedAtRoute("GetSpotAction", new { result.Data.spotId }, result.Data.spotId) : NoContent();
    }


    [HttpOptions]
    public IActionResult GetSpotsOptions()
    {
        Response.Headers.Append("Allow", "GET, HEAD, POST, PUT, PATCH, OPTIONS");

        return Ok();
    }

}
