using Jacustran.Application.Contracts.Abstractions.MediatR;

namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommand : ICommand<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsImportantCity { get; set; }  
    public int Population { get; set; } 
    public string? ImageUrl { get; set; } 

}
