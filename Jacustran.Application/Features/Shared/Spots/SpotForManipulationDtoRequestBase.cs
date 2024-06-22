namespace Jacustran.Application.Features.Shared.Spots;



public abstract class SpotForManipulationDtoRequestBase : BaseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public StarRating StarRating { get; set; }
}


