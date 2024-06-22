namespace Jacustran.Application.Features.Shared.Spots;

public class SpotForManipulationDtoBaseValidator : AbstractValidator<SpotForManipulationDtoBase>
{
    public SpotForManipulationDtoBaseValidator()
    {
        RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.ImageUrl)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.StarRating)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
