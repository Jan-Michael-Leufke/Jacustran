using Jacustran.Application.Features.Citites.Commands.CreateCities;
using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;
using Jacustran.Application.Features.Citites.Commands.PartialUpsertCity;
using Jacustran.Application.Features.Citites.Commands.UpsertCity;
using Jacustran.Application.Features.Citites.Queries.GetCities;
using Jacustran.Application.Features.Citites.Queries.GetCity;
using Jacustran.Application.Features.Citites.Queries.GetCityCollection;
using Jacustran.Domain.ValueObjects;
using Jacustran.SharedKernel.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace Jacustran.Application.Profiles;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        //Create City
        CreateMap<CreateCityRequest, CreateCityCommand>();
        CreateMap<CreateCityCommand, City>().ForMember(d => d.Name, opt => opt.MapFrom(s => LocationName.Create(s.Name).Data));
        CreateMap<CreateCity_CreateSpotsDto, Spot>().ForMember(d => d.Rating, opt => opt.MapFrom(s => s.StarRating))
            .ConstructUsing(dto => new Spot(LocationName.Create(dto.Name).Data, dto.Description, dto.ImageUrl, dto.StarRating));


        //Create Cities
        CreateMap<IEnumerable<CreateCitiesRequest>, CreateCitiesCommand>().ForMember(d => d.Cities, opt => opt.MapFrom(s => s));
        CreateMap<CreateCitiesRequest, CreateCitiesCommandInnerDto>();

        CreateMap<CreateCitiesRequest, CreateCitiesCommand>();
        CreateMap<CreateCitiesRequestDto, CreateCitiesCommandInnerDto>();

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
        CreateMap<UpsertCity_UpsertSpotsDto, Spot>();

        //partial upsert city
        CreateMap<PartialUpsertCityPatchDto, City>().ReverseMap();
        CreateMap<PartialUpsertCityPatchDto_PartialUpsertSpotsDto, Spot>().ForMember(d => d.Rating, opt => opt.MapFrom(s => s.StarRating ));
        CreateMap<Spot, PartialUpsertCityPatchDto_PartialUpsertSpotsDto>().ForMember(d => d.StarRating, opt => opt.MapFrom(s => s.Rating));
        CreateMap<PartialUpsertCityRequest, PartialUpsertCityCommand>().ConstructUsing(request => 
        new PartialUpsertCityCommand(request.CityId, request.Body.PatchDocument));

        
    }
    
    

}

