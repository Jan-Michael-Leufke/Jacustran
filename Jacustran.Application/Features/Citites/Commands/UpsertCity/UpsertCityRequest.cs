using Jacustran.Application.Abstractions.Api;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Application.Features.Citites.Commands.UpdateCity;


public class UpsertCityRequest : BaseRequest
{
    public const string Route = "api/cities/{CityId:guid}";

    [FromRoute]
    public Guid CityId { get; set; }

    [FromBody]
    public UpsertCityRequestBody Body { get; set; } = null!;



}

public class UpsertCityRequestBody
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsImportantCity { get; set; }

    public int Population { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<UpsertCityRequest_UpsertSpotsDto>? Spots { get; set; }
}


public class UpsertCityRequest_UpsertSpotsDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public StarRating StarRating { get; set; }
}
