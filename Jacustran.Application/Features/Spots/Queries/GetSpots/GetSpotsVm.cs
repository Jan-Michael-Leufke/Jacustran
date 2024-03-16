using System.Xml.Linq;

namespace Jacustran.Application.Features.Spots.Queries.GetSpots;

public class GetSpotsVm
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StarRating Rating { get; set; }

}