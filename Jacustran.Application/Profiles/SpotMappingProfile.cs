using Jacustran.Application.Features.Spots.Queries.GetSpots;
using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;

namespace Jacustran.Application.Profiles;

public class SpotMappingProfile : Profile
{
    public SpotMappingProfile()
    {
        CreateMap<Spot, GetSpotsVm>();
        CreateMap<CreateSpotRequest,CreateSpotCommand>();
        CreateMap<CreateSpotCommand, Spot>();
    }
}
