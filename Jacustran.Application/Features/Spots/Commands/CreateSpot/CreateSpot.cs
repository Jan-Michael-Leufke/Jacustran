using Jacustran.Application.Features.Citites.Commands.CreateCity;
using Jacustran.SharedKernel.Interfaces.Persistence;
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

        public CreateSpot_CreateCityDto? City { get; set; }
    }

    public class CreateSpotCommandHandler : ICommandHandler<CreateSpotCommand, Guid>
    {
        private readonly IAsyncRepository<Spot, Guid> _spotRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        
        public CreateSpotCommandHandler(IAsyncRepository<Spot, Guid> spotRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _spotRepository = spotRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreateSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = _mapper.Map<Spot>(request);
            
            if(request.City != null)
            {
                var city = _mapper.Map<City>(request.City);
                
                spot.Town = city;
            }
            
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

        public CreateSpot_CreateCityDto? City { get; set; }
    }

    public class CreateSpotCommandValidator : AbstractValidator<CreateSpotCommand>
    {
        public CreateSpotCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ImageUrl)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            //RuleFor(p => p.Rating)
            //.NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.City).SetValidator(new CreateSpot_CreateCityDtoValidator());
        }
    }

    public class CreateSpot_CreateCityDtoValidator : AbstractValidator<CreateSpot_CreateCityDto?> 
    {
        public CreateSpot_CreateCityDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from request in Api Layer");
            RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");    
        }
    }
}

public class CreateSpot_CreateCityDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public bool IsImportantCity { get; set; }
    public int Population { get; set; }
    public string? ImageUrl { get; set; }
}