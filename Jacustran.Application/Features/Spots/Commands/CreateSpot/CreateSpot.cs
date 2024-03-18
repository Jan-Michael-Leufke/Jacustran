using System.ComponentModel.DataAnnotations;

namespace Jacustran.Application.Features.Spots.Commands.CreateSpot;

public static class CreateSpot
{
    public class CreateSpotCommand : ICommand<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
    }

    public class CreateSpotCommandHandler : ICommandHandler<CreateSpotCommand, Guid>
    {
        private readonly IAsyncRepository<Spot> _spotRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        
        public CreateSpotCommandHandler(IAsyncRepository<Spot> spotRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _spotRepository = spotRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreateSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = _mapper.Map<Spot>(request);

            _spotRepository.Add(spot);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(spot.Id);
        }
    }

    public class CreateSpotRequest
    {
        [Required(ErrorMessage = "Name required from Debug Annotation from CreateSpotRequest")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
    }

    public class CreateSpotCommandValidator : AbstractValidator<CreateSpotCommand>
    {
        public CreateSpotCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required cpcv.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters cpcv.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters cpcv.");

            RuleFor(p => p.ImageUrl)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters cpcv.");

            //RuleFor(p => p.Rating)
                //.NotEmpty().WithMessage("{PropertyName} is required cpcv.");
        }
    }
}
