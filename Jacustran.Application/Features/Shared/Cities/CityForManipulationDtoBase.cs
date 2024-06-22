using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Shared.Spots;

namespace Jacustran.Application.Features.Shared.Cities;


public abstract class CityForManipulationDtoBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Population { get; set; }
    public bool IsImportantCity { get; set; }

}


