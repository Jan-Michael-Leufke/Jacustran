using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Features.Shared.Cities;

public abstract class CityForManipulationDtoRequestBase : BaseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Population { get; set; }
    public bool IsImportantCity { get; set; }
}
