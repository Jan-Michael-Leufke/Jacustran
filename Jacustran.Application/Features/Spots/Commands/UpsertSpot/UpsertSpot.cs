using System.Diagnostics.Tracing;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Spots.Commands.UpdateSpot;

public static class UpsertSpot
{
    public class UpsertSpotRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }


        public UpsertSpotRequest_UpsertLocationDto? Location { get; set; }
    }

    public class UpsertSpotRequest_UpsertLocationDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsImportantCity { get; set; }
        public int Population { get; set; }
        public string? ImageUrl { get; set; }
        public LocationType LocationType { get; set; }
    }

    public record UpsertSpotCommand : ICommand<(Guid spotId, bool created)>
    {
        public Guid SpotId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }

        public UpsertSpotRequest_UpsertLocationDto? Location { get; set; }
    }

    public class UpsertSpotCommandHandler : ICommandHandler<UpsertSpotCommand, (Guid, bool)>
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       

        public UpsertSpotCommandHandler(ISpotRepository spotRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _spotRepository = spotRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<(Guid, bool)>> Handle(UpsertSpotCommand request, CancellationToken cancellationToken)
        {

            var spot = request.Location is null ? 
                await _spotRepository.GetByIdAsync(request.SpotId, cancellationToken) : 
                await _spotRepository.GetSpotWithTown(request.SpotId, cancellationToken);

            if (spot == null)
            {
                spot = _mapper.Map<Spot>(request);
                spot.Id = request.SpotId;
                
                MapLocationToNewTown(request, spot);

                _spotRepository.Add(spot);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result<(Guid, bool)>.Success((spot.Id, true));
            }

            _mapper.Map(request, spot);

            MapLocationToExistingTown(request, spot);

            _spotRepository.Update(spot);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        private void MapLocationToNewTown(UpsertSpotCommand request, Spot spot)
        {
            if(request.Location is null) return;

            spot.Town = request.Location.LocationType switch
            {
                LocationType.City => _mapper.Map<City>(request.Location),
                LocationType.Town => _mapper.Map<Town>(request.Location),
                LocationType.None  => null,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void MapLocationToExistingTown(UpsertSpotCommand request, Spot spot)
        {
            if (request.Location is null) return;

            spot.Town = spot.Town switch
            {
                City city => _mapper.Map(request.Location, city),
                Town town => _mapper.Map(request.Location, town),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public class UpsertSpotCommandValidator : AbstractValidator<UpsertSpotCommand>
        {
            public UpsertSpotCommandValidator()
            {
                RuleFor(x => x.SpotId).NotEmpty().WithMessage("SpotId is required");
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x.Rating).IsInEnum().WithMessage("StarRating is required");
                RuleFor(x => x.Location).SetValidator(new UpsertSpotRequest_UpsertLocationDtoValidator());
            }
        }

        public class UpsertSpotRequest_UpsertLocationDtoValidator : AbstractValidator<UpsertSpotRequest_UpsertLocationDto?>
        {
            public UpsertSpotRequest_UpsertLocationDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x.Population).GreaterThan(0).WithMessage("Population is required");
            }
        }   
    }
}

