using Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Jacustran.Application.Features.Citites.Commands.PartialUpsertCity;

public class PartialUpsertCityRequest : BaseRequest
{
    public const string Route = "api/cities/{cityId:guid}";

    [FromRoute]
    public Guid CityId { get; set; }

    [FromBody]  
    public PartialUpsertCityRequestBody Body { get; set; } = null!;
    
    

}

public class PartialUpsertCityRequestBody
{
    public JsonPatchDocument<PartialUpsertCityPatchDto>? PatchDocument { get; set; }

}   
