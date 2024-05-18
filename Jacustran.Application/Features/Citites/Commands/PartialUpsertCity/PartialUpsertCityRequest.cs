using Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Application.Features.Citites.Commands.PartialUpsertCity;

public class PartialUpsertCityRequest : BaseRequest
{
    public const string Route = "api/citites/{cityId:guid}";

    JsonPatchDocument<PartialUpsertCityPatchDto>? PatchDocument { get; set; } 
}
