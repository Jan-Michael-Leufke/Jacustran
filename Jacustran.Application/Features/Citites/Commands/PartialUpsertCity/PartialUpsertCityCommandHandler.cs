
using Jacustran.Application.Features.Shared;
using Jacustran.Domain.ValueObjects;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

internal class PartialUpsertCityCommandHandler : CommandHandlerBase<PartialUpsertCityCommand, (Guid, bool)> 
{
    private readonly ICityRepository _cityRepository;
    private readonly IValidator<PartialUpsertCityPatchDto> _validator;

    public PartialUpsertCityCommandHandler(
        ICityRepository cityRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IValidator<PartialUpsertCityPatchDto> validator) 
        : base(unitOfWork, mapper)
    {
        _cityRepository = cityRepository;
        _validator = validator;
    }

    public override async Task<Result<(Guid, bool)>> Handle(PartialUpsertCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetCityWithSpots(request.CityId, cancellationToken);

        PartialUpsertCityPatchDto cityToPatch;

        Result<(Guid, bool)>? validationResult;


        if (city == null)
        {
            cityToPatch = new PartialUpsertCityPatchDto();

            request.PatchDocument!.ApplyTo(cityToPatch);

            validationResult = await ValidateDtoAsync(cityToPatch, _validator, cancellationToken);

            if (validationResult != null) return validationResult;

            city = _mapper.Map<City>(cityToPatch);

            city.Id = request.CityId;

            _cityRepository.Add(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<(Guid, bool)>.Success((city.Id, true));
        }

        cityToPatch = _mapper.Map<PartialUpsertCityPatchDto>(city);

        request.PatchDocument!.ApplyTo(cityToPatch);

        validationResult = await ValidateDtoAsync(cityToPatch, _validator, cancellationToken);

        if (validationResult != null) return validationResult;


        city.Name = LocationName.Create(cityToPatch.Name).Data;
        city.Population = cityToPatch.Population;
        city.Description = cityToPatch.Description;
        city.ImageUrl = cityToPatch.ImageUrl;
        city.IsImportantCity = cityToPatch.IsImportantCity;

        if (cityToPatch.Spots != null)
        {
            foreach (var spot in cityToPatch.Spots)
            {
                var existingSpot = city.Spots.FirstOrDefault(s => s.Id == spot.Id);

                if (existingSpot is not null)
                {
                    existingSpot.Name = LocationName.Create(spot.Name).Data;
                    existingSpot.Description = spot.Description;
                    existingSpot.ImageUrl = spot.ImageUrl;
                    existingSpot.Rating = spot.StarRating;
                }
            }
        }

        //_mapper.Map(cityToPatch, city);

        //_cityRepository.Update(city);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}

