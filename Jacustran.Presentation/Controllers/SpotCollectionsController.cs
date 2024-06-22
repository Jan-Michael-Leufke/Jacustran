
using Jacustran.Presentation.Abstractions;
using Jacustran.Application.Modelbinders;
using Microsoft.AspNetCore.Http;
using static Jacustran.Application.Features.Spots.Commands.CreateSpots.CreateSpots;
using static Jacustran.Application.Features.Spots.Queries.GetSpotCollection.GetSpotCollection;

namespace Jacustran.Presentation.Controllers;

[Route("api/SpotCollections")]
public class SpotCollectionsController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{

    [HttpGet("({spotIds})", Name = "GetSpotCollectionAction")]
    public async Task<ActionResult<IEnumerable<GetSpotCollectionVm>>> GetSpotCollection(
               [ModelBinder(typeof(EnumerableArrayModelBinderType<Guid>))][FromRoute] IEnumerable<Guid> spotIds, 
               CancellationToken token)
    {
        var result = await _sender.Send(new GetSpotCollectionQuery(spotIds), token);

        return Ok(result.Data);
    }


    [HttpPost]
    public async Task<ActionResult<IEnumerable<Guid>>> CreateSpots(
        IEnumerable<CreateSpotsRequest> requests, CancellationToken token)
    {
        var command = new CreateSpotsCommand();

        command.Requests = _mapper.Map<IEnumerable<CreateSpotsCommandInnerDto>>(requests);

        var result = await _sender.Send(command, token);

        if (result.IsFailure) return FailureToProblemDetails(result);

        return CreatedAtRoute("GetSpotCollectionAction", new { spotIds = string.Join(',', result.Data!) }, result.Data);
    }

    [HttpOptions]
    public IActionResult GetSpotCollectionOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,OPTIONS");
        return Ok();
    }
}
