namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public record CreateCityCommand : ICommand<Guid>
{    
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public bool IsImportantCity { get; set; }  
    public int Population { get; set; } 
    public string? ImageUrl { get; set; } 

    public ICollection<CreateCity_CreateSpotsDto>? Spots { get; set;} = new List<CreateCity_CreateSpotsDto>();

}
