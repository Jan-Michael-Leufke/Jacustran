using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Features.Shared.Cities;

public class CityForManipulationDtoBaseValidator : AbstractValidator<CityForManipulationDtoBase>
{
    public CityForManipulationDtoBaseValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters");
        RuleFor(c => c.Population).GreaterThan(0).WithMessage("Population must be greater than 0")
            .LessThan(int.MaxValue).WithMessage($"Population must not exceed {int.MaxValue-1}");

    }
}

