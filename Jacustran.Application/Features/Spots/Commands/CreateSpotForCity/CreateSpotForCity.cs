using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Spots.Commands.CreateSpotForCity;

public static class CreateSpotForCity
{
    public record CreateSpotForCityRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
    }

    public record CreateSpotForCityCommand : ICommand<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public StarRating Rating { get; set; }
        public Guid CityId { get; set; }
    }
    
    public class CreateSpotForCityValidator : AbstractValidator<CreateSpotForCityCommand>
    {
        public CreateSpotForCityValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ImageUrl)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            
            RuleFor(p => p.CityId).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }


    internal class CreateSpotForCityCommandHandler : ICommandHandler<CreateSpotForCityCommand, Guid>
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSpotForCityCommandHandler(ISpotRepository spotRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _spotRepository = spotRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateSpotForCityCommand request, CancellationToken token)
        {
            if(!await _spotRepository.IsCityIdValid(request.CityId, token)) 
                return Result<Guid>.Failure(CityErrors.NotFound(request.CityId));

            var spot = _mapper.Map<Spot>(request);

            _spotRepository.Add(spot);

            await _unitOfWork.SaveChangesAsync(token);

            return Result<Guid>.Success(spot.Id);
        }
    }
}
