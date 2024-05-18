using Jacustran.Application.Features.Citites.Queries.GetCity_Spot;
using Jacustran.Application.Features.Citites.Queries.GetCity_Spots;
using Jacustran.Application.Features.Spots.Commands.CreateSpot;
using static Jacustran.Application.Features.Spots.Commands.CreateSpot.CreateSpot;
using static Jacustran.Application.Features.Spots.Commands.CreateSpotForCity.CreateSpotForCity;
using static Jacustran.Application.Features.Spots.Commands.CreateSpots.CreateSpots;
using static Jacustran.Application.Features.Spots.Commands.PartialUpsertSpot.PartialUpsertSpot;
using static Jacustran.Application.Features.Spots.Commands.UpdateSpot.UpsertSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpot.GetSpot;
using static Jacustran.Application.Features.Spots.Queries.GetSpotCollection.GetSpotCollection;
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
        CreateMap<CreateSpotCommand, Spot>().ForMember(d => d.Town, opt => opt.MapFrom(s => s.City));
        CreateMap<CreateSpot_CreateCityDto, Town>();
        CreateMap<CreateSpot_CreateCityDto, City>();

        //CreateSpotForCity
        CreateMap<CreateSpotForCityRequest, CreateSpotForCityCommand>();
        CreateMap<CreateSpotForCityCommand, Spot>().ForMember(d => d.TownId, opt => opt.MapFrom(s => s.CityId));




        //GetSpot
        CreateMap<Spot, GetSpotVm>();
        CreateMap<Town, GetSpotVm_TownDto>();

        //GetCity_Spots
        CreateMap<Spot, GetCity_SpotsVm>();

        //GetCity_Spot
        CreateMap<Spot, GetCity_SpotVm>();

        //GetSpotCollection
        CreateMap<Spot, GetSpotCollectionVm>();

        //CreateSpots
        CreateMap<CreateSpotsRequest, CreateSpotsCommandInnerDto>();
        CreateMap<CreateSpotsCommandInnerDto, Spot>();

        //upsertSpot
        CreateMap<UpsertSpotRequest, UpsertSpotCommand>();
        CreateMap<UpsertSpotCommand, Spot>(); //.ForMember(d => d.Town, opt => opt.MapFrom(s => s.Location));

        CreateMap<UpsertSpotRequest_UpsertLocationDto, Town>();
        CreateMap<UpsertSpotRequest_UpsertLocationDto, City>();

        //PartialUpsertSpot
        CreateMap<PartialUpsertSpotPatchDto, Spot>().ReverseMap(); //.ForMember(d => d.Town, opt => opt.MapFrom(s => s.Location)).ReverseMap();
        CreateMap<PartialUpsertSpotPatchDto_PartialUpsertLocationDto, City>().ReverseMap();
        CreateMap<PartialUpsertSpotPatchDto_PartialUpsertLocationDto, Town>().ReverseMap();

    }


}

//{
//public class CreateSpot_CreateCityDtoToTownConverter : ITypeConverter<CreateSpot_CreateCityDto, Town>
//    public Town Convert(CreateSpot_CreateCityDto source, Town destination, ResolutionContext context)
//    {
//        var converted = new City()
//        {
//            Name = source.Name,
//            Description = source.Description,
//            Population = source.Population,
//            ImageUrl = source.ImageUrl,
//            IsImportantCity = source.IsImportantCity
//        };

//        return converted;
//    }
//}