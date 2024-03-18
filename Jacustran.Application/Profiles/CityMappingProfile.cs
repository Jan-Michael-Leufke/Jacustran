using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Application.Features.Citites.Queries.GetCity;

namespace Jacustran.Application.Profiles;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        //Create City
        CreateMap<CreateCityRequest, CreateCityCommand>();
        CreateMap<CreateCityCommand, City>();

        //Get Cities
        CreateMap<City, GetCitiesVm>();

        //Get City
        CreateMap<City, GetCityVm>();
        CreateMap<Spot, GetCityVm_SpotsDto>();
    }

}
