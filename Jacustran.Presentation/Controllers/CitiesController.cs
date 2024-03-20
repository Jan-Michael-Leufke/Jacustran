using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Application.Features.Citites.Queries.GetCity;
using Jacustran.Application.Features.Citites.Queries.GetCity_Spot;
using Jacustran.Application.Features.Citites.Queries.GetCity_Spots;

namespace Jacustran.Presentation.Controllers;

public class CitiesController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]
    [HttpHead]
    public async Task<ActionResult<IEnumerable<GetCitiesVm>>> GetCities(CancellationToken cancellationToken)
    {
        return Ok((await _sender.Send(new GetCitiesQuery(), cancellationToken)).Data);
    }

    [HttpGet("{id:guid}", Name = "GetCityAction")]
    [HttpHead("{id:guid}")]
    public async Task<ActionResult<GetCityVm>> GetCity(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCityQuery { Id = id }, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }

    [HttpGet("{id:guid}/spots")]
    [HttpHead("{id:guid}/spots")]
    public async Task<ActionResult<IEnumerable<GetCity_SpotsVm>>> GetCity_Spots(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCity_SpotsQuery(id), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }


    [HttpGet("{id:guid}/spots/{spotId:guid}")]
    [HttpHead("{id:guid}/spots{spotId:guid}")]
    public async Task<ActionResult<GetCity_SpotVm>> GetCity_Spots(Guid id, Guid spotId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCity_SpotQuery(id, spotId), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }



    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCity(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var res = _mapper.Map<CreateCityCommand>(request);

        var result = await _sender.Send(_mapper.Map<CreateCityCommand>(request), cancellationToken);

        return result.IsSuccess ? CreatedAtRoute("GetCityAction", new { Id = result.Data }, result.Data) 
                                : FailureToProblemDetails(result);
    }
}
