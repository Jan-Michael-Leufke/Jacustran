using AutoMapper.Internal;
using Jacustran.Application.Features.Citites.Commands.CreateCities;
using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using Jacustran.Presentation.Modelbinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Reflection;

namespace Jacustran.Presentation.Controllers;

public class CityCollectionsController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet("({cityIds})", Name = "GetCityCollectionAction")]
    public async Task<ActionResult<IEnumerable<GetCityCollectionVm>>> GetCityCollection(
        [ModelBinder(typeof(EnumerableModelBinder))] [FromRoute] IEnumerable<Guid> cityIds, CancellationToken token)
    {
        var result = await _sender.Send(new GetCityCollectionQuery(cityIds), token);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Guid>>> CreateCities(IEnumerable<CreateCitiesRequest> requests, CancellationToken token)
    {
        var command = new CreateCitiesCommand();

        command.Requests = _mapper.Map<IEnumerable<CreateCitiesCommandInnerDto>>(requests);

        var result = await _sender.Send(command, token);

        if (result.IsFailure) return FailureToProblemDetails(result);

        return CreatedAtRoute("GetCityCollectionAction", new { cityIds = string.Join(',', result.Data!) }, result.Data);
    }
}


