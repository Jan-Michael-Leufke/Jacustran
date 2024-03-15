using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Domain.Entity.Entities;

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
    }

}
