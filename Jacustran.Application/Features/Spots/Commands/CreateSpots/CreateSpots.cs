using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Spots.Commands.CreateSpots;

public static class CreateSpots
{
    public record CreateSpotsRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public StarRating Rating { get; init; }
    }

    public record CreateSpotsCommandInnerDto
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public StarRating Rating { get; init; }
    }

    public record CreateSpotsCommand : ICommand<IEnumerable<Guid>>
    {
        public IEnumerable<CreateSpotsCommandInnerDto> Requests { get; set; } = new List<CreateSpotsCommandInnerDto>();
    }

    internal class CreateSpotsCommandHandler : ICommandHandler<CreateSpotsCommand, IEnumerable<Guid>>
    {
        private readonly IAsyncRepository<Spot, Guid> _spotRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSpotsCommandHandler(IAsyncRepository<Spot, Guid> spotRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _spotRepository = spotRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Guid>>> Handle(CreateSpotsCommand request, CancellationToken token)
        {
            var spots = _mapper.Map<IEnumerable<Spot>>(request.Requests);

            _spotRepository.AddRange(spots);

            await _unitOfWork.SaveChangesAsync(token);

            return Result<IEnumerable<Guid>>.Success(spots.Select(s => s.Id));
        }

        public class CreateSpotsCommandValidator : AbstractValidator<CreateSpotsCommand> 
        {
            public CreateSpotsCommandValidator()
            {
                RuleFor(x => x.Requests).NotEmpty();
                RuleForEach(x => x.Requests).SetValidator(new CreateSpotsCommandInnerDtoValidator());
            }
        }

        public class CreateSpotsCommandInnerDtoValidator : AbstractValidator<CreateSpotsCommandInnerDto>
        {
            public CreateSpotsCommandInnerDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
                RuleFor(x => x.Description).MaximumLength(1000);
                RuleFor(x => x.ImageUrl).MaximumLength(2000);
                RuleFor(x => x.Rating).IsInEnum();
            }
        }   
    }
}
