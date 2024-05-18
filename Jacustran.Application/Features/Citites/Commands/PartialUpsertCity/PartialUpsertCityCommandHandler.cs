
using Jacustran.Application.Features.Shared;
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
        IValidator<PartialUpsertCityPatchDto> validator) : base(unitOfWork, mapper)
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

            request.PatchDocument.ApplyTo(cityToPatch);

            validationResult = await ValidateDtoAsync(cityToPatch, _validator, cancellationToken);

            if (validationResult != null) return validationResult;

            city = _mapper.Map<City>(cityToPatch);

            city.Id = request.CityId;

            _cityRepository.Add(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<(Guid, bool)>.Success((city.Id, true));
        }

        cityToPatch = _mapper.Map<PartialUpsertCityPatchDto>(city);

        request.PatchDocument.ApplyTo(cityToPatch);

        validationResult = await ValidateDtoAsync(cityToPatch, _validator, cancellationToken);

        if (validationResult != null) return validationResult;

        _mapper.Map(cityToPatch, city);

        _cityRepository.Update(city);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}

