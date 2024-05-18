using Jacustran.Application.Features.Citites.Commands.CreateCity;
using MediatR;

namespace Jacustran.Presentation.Controllers.City;

public class CreateCity : AsyncEndpointBase.WithRequest<CreateCityRequest>.WithResponse<CreateCityResponse>
{
    public CreateCity(ISender sender, IMapper mapper) : base(sender, mapper) { }

    [HttpPost(CreateCityRequest.Route)]
    public override async Task<ActionResult<CreateCityResponse>> HandleAsync([FromBody] CreateCityRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(_mapper.Map<CreateCityCommand>(request), cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : FailureToProblemDetails(result);
    }
}


