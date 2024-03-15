using FluentValidation;
using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Validation;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters for testing purposes");
    }
}
