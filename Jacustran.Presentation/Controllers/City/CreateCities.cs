using Jacustran.Application.Features.Citites.Commands.CreateCities;
using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using MediatR;

namespace Jacustran.Presentation.Controllers.City;

public class CreateCities : AsyncEndpointBase.WithRequest<CreateCitiesRequest>.WithResponse<CreateCitiesResponse>
{
    public CreateCities(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpPost(CreateCitiesRequest.Route)]
    public override async Task<ActionResult<CreateCitiesResponse>> HandleAsync(CreateCitiesRequest request, 
                                                                               CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(_mapper.Map<CreateCitiesCommand>(request), cancellationToken);

        return result.IsSuccess ? CreatedAtRoute("GetCityCollectionAction", 
                                  new  { CityIds = string.Join(',', result.Data.CityIds) }, 
                                  result.Data.CityIds) : 
                                  FailureToProblemDetails(result);
    }
}
