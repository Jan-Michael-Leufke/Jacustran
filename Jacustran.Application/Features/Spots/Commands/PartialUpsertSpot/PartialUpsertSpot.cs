
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Spots.Commands.PartialUpsertSpot;

public static class PartialUpsertSpot
{
    public class PartialUpsertSpotPatchDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating? Rating { get; set; }

        public PartialUpsertSpotPatchDto_PartialUpsertLocationDto? Location { get; set; }   
    }

    public class PartialUpsertSpotPatchDto_PartialUpsertLocationDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating? Rating { get; set; }

        public LocationType LocationType { get; set; }
    }

    public class PartialUpsertSpotCommand : ICommand<(Guid spotId, bool created)>
    {
        public Guid SpotId { get; set; }
        public JsonPatchDocument<PartialUpsertSpotPatchDto> PatchDocument { get; set; } = new();
    }


    internal class PartialUpsertSpotCommandHandler : CommandHandlerBase<PartialUpsertSpotCommand, (Guid, bool)>
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IValidator<PartialUpsertSpotPatchDto> _validator;

        public PartialUpsertSpotCommandHandler(ISpotRepository spotRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IValidator<PartialUpsertSpotPatchDto> validator) : base(unitOfWork, mapper)
        {
            _spotRepository = spotRepository;
            _validator = validator;
        }

        public override async Task<Result<(Guid, bool)>> Handle(PartialUpsertSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = await _spotRepository.GetSpotWithTown(request.SpotId, cancellationToken);
            
            PartialUpsertSpotPatchDto spotToPatch;

            Result<(Guid, bool)>? validationResult;

            if (spot == null)
            {
                spotToPatch = new PartialUpsertSpotPatchDto();

                request.PatchDocument.ApplyTo(spotToPatch);

                validationResult = await ValidateDtoAsync(spotToPatch, _validator, cancellationToken);

                if (validationResult is not null) return validationResult;
                
                spot = _mapper.Map<Spot>(spotToPatch);

                if (spotToPatch.Location is not null)
                {
                    spot.Town = spotToPatch.Location.LocationType switch
                    {
                        LocationType.City => _mapper.Map<City>(spotToPatch.Location),
                        LocationType.Town => _mapper.Map<Town>(spotToPatch.Location),
                        LocationType.None => null,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }

                spot.Id = request.SpotId;

                _spotRepository.Add(spot);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result<(Guid, bool)>.Success((spot.Id, true));
            }

            spotToPatch = _mapper.Map<PartialUpsertSpotPatchDto>(spot);
            
            request.PatchDocument.ApplyTo(spotToPatch); 

            validationResult = await ValidateDtoAsync(spotToPatch, _validator, cancellationToken);

            if (validationResult is not null) return validationResult;

            _mapper.Map(spotToPatch, spot);

            if (spotToPatch.Location is not null)
            {
                spot.Town = spot.Town switch
                {
                    City city => _mapper.Map(spotToPatch.Location, city),
                    Town town => _mapper.Map(spotToPatch.Location, town),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            _spotRepository.Update(spot);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(); 
        }
    }


    public class PartialUpsertSpotCommandValidator : AbstractValidator<PartialUpsertSpotCommand>
    {
        public PartialUpsertSpotCommandValidator()
        {
            RuleFor(x => x.SpotId).NotEmpty();
            RuleFor(x => x.PatchDocument).NotEmpty();
        }
    }

    public class PartialUpsertSpotPatchDtoValidator : AbstractValidator<PartialUpsertSpotPatchDto>
    {
        public PartialUpsertSpotPatchDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
            RuleFor(x => x.Description).NotEmpty().When(x => x.Description is not null);
            RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl is not null);
            RuleFor(x => x.Rating).IsInEnum().When(x => x.Rating is not null);
            RuleFor(x => x.Location).SetValidator(new PartialUpsertSpotPatchDto_PartialUpsertLocationDtoValidator());     
        }
    }       

  
    public class PartialUpsertSpotPatchDto_PartialUpsertLocationDtoValidator : AbstractValidator<PartialUpsertSpotPatchDto_PartialUpsertLocationDto?>
    {
        public PartialUpsertSpotPatchDto_PartialUpsertLocationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
            RuleFor(x => x.Description).NotEmpty().When(x => x.Description is not null);
            RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl is not null);
            RuleFor(x => x.Rating).IsInEnum().When(x => x.Rating is not null);
        }
    }   

}
