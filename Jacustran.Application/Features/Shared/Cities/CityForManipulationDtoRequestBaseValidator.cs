namespace Jacustran.Application.Features.Shared.Cities;

public class CityForManipulationDtoRequestBaseValidator : AbstractValidator<CityForManipulationDtoRequestBase>
{
    public CityForManipulationDtoRequestBaseValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required BC");
        RuleFor(c => c.Description).MaximumLength(10).WithMessage("Description must not exceed 10 characters BC");
        RuleFor(c => c.Population).GreaterThan(0).WithMessage("Population must be greater than 0 BC")
            .LessThan(int.MaxValue).WithMessage($"Population must not exceed {int.MaxValue - 1} BC");
    }



}
