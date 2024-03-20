using Jacustran.Application.Features.Citites.Commands.CreateCities;
using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Application.Features.Citites.Queries.GetCity;
using Jacustran.Application.Features.Citites.Queries.GetCityCollection;

namespace Jacustran.Application.Profiles;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        //Create City
        CreateMap<CreateCityRequest, CreateCityCommand>();
        CreateMap<CreateCityCommand, City>();
        CreateMap<CreateCity_CreateSpotsDto, Spot>();

        //Create Cities
        CreateMap<IEnumerable<CreateCitiesRequest>, CreateCitiesCommand>().ForMember(d => d.Requests, opt => opt.MapFrom(s => s));
        CreateMap<CreateCitiesRequest, CreateCitiesCommandInnerDto>();
        CreateMap<CreateCitiesCommandInnerDto, City>();
        CreateMap<CreateCitiesCommand, City>();
        CreateMap<CreateCities_CreateSpotsDto, Spot>();

        //Get Cities
        CreateMap<City, GetCitiesVm>();

        //Get City
        CreateMap<City, GetCityVm>();
        CreateMap<Spot, GetCityVm_SpotsDto>();


        //get city collection
        CreateMap<City, GetCityCollectionVm>();
    }

}
