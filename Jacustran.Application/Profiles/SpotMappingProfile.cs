using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;
using static Jacustran.Application.Features.Spots.Commands.CreateSpotForCity.CreateSpotForCity;
using static Jacustran.Application.Features.Spots.Queries.GetSpot.GetSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpots.GetSpots;

namespace Jacustran.Application.Profiles;

public class SpotMappingProfile : Profile
{
    public SpotMappingProfile()
    {
        //GetSpots
        CreateMap<Spot, GetSpotsVm>();

        //CreateSpot
        CreateMap<CreateSpotRequest,CreateSpotCommand>();
        CreateMap<CreateSpotCommand, Spot>();

        //CreateSpotForCity
        CreateMap<CreateSpotForCityRequest, CreateSpotForCityCommand>();
        CreateMap<CreateSpotForCityCommand, Spot>().ForMember(d => d.TownId, opt => opt.MapFrom(s => s.CityId));

        //GetSpot
        CreateMap<Spot, GetSpotVm>();
        CreateMap<Town, GetSpotVm_TownDto>();

    }
}
