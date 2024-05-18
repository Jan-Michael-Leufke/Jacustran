using Jacustran.Application.Features.Citites.Commands.UpdateCity;
using Jacustran.Application.Features.Citites.Queries.GetCity;
using Jacustran.SharedKernel.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.Buffers;
using System.Text;

namespace Jacustran.Presentation.Controllers.City;

public class UpsertCity : AsyncEndpointBase.WithRequest<UpsertCityRequest>.WithResponseAsIActionResult
{
    public UpsertCity(ISender sender, IMapper mapper) : base(sender, mapper) { }


    [HttpPut(UpsertCityRequest.Route)]
    public async override Task<IActionResult> HandleAsync(UpsertCityRequest request, CancellationToken cancellationToken = default)
    {


        var command = _mapper.Map<UpsertCityCommand>(request);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return FailureToProblemDetailsAsIActionResult(result);

        return result.Data.created ? CreatedAtRoute("GetCityAction", new { id = result.Data.cityId }, result.Data.cityId) : NoContent();

    }
}


