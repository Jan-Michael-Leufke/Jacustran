using Jacustran.Application.Features.Citites.Commands.PartialUpsertCity;

namespace Jacustran.Presentation.Controllers.City;

public class PartialUpsertCity : AsyncEndpointBase.WithRequest<PartialUpsertCityRequest>.WithResponseAsIActionResult
{
    public PartialUpsertCity(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpPatch(PartialUpsertCityRequest.Route)]
    public async override Task<IActionResult> HandleAsync(PartialUpsertCityRequest request, CancellationToken cancellationToken = default)
    {
        var command = _mapper.Map<PartialUpsertCityCommand>(request);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return FailureToProblemDetailsAsIActionResult(result);

        return result.Data.created ? CreatedAtRoute("GetCityAction", new { id = result.Data.cityId }, result.Data.cityId) : NoContent();
    }
}
