namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public record CreateCityCommand : ICommand<CreateCityResponse>
{    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public bool IsImportantCity { get; set; }  
    public int Population { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<CreateCity_CreateSpotsDto>? Spots { get; set;}

}
