using Jacustran.Application.Features.Citites.Commands.CreateCities;
using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;
using Jacustran.Application.Features.Citites.Commands.UpdateCity;
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
        CreateMap<CreateCity_CreateSpotsDto, Spot>().ForMember(d => d.Rating, opt => opt.MapFrom(s => s.StarRating))
            .ConstructUsing(dto  => new Spot(dto.Name, dto.Description, dto.ImageUrl, dto.StarRating));

        //Create Cities
        CreateMap<IEnumerable<CreateCitiesRequest>, CreateCitiesCommand>().ForMember(d => d.Requests, opt => opt.MapFrom(s => s));
        CreateMap<CreateCitiesRequest, CreateCitiesCommandInnerDto>();
        CreateMap<CreateCitiesCommandInnerDto, City>();
        //CreateMap<CreateCitiesCommand, City>();
        CreateMap<CreateCities_CreateSpotsDto, Spot>();

        //Get Cities
        CreateMap<City, GetCitiesVm>();

        //Get City
        CreateMap<City, GetCityVm>();
        CreateMap<Spot, GetCityVm_SpotsDto>();


        //get city collection
        CreateMap<City, GetCityCollectionVm>();

        //upsert city
        CreateMap<UpsertCityRequest, UpsertCityCommand>()
            .ConstructUsing(request => new UpsertCityCommand()
            {
               CityId = request.CityId, 
               Name = request.Body.Name, 
               Description =  request.Body.Description, 
               IsImportantCity = request.Body.IsImportantCity, 
               Population = request.Body.Population, 
               ImageUrl = request.Body.ImageUrl,
               Spots = request.Body.Spots
            });

        CreateMap<UpsertCityCommand, City>();
        CreateMap<UpsertCityRequest_UpsertSpotsDto, Spot>();

        //partial update city
        CreateMap<PartialUpsertCityPatchDto, City>().ReverseMap();
        CreateMap<PartialUpsertCityPatchDto_PartialUpsertSpotsDto, Spot>().ReverseMap();
    }

}
