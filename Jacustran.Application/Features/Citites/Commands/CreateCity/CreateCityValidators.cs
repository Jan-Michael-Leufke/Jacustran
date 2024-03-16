namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from App Layer");
        RuleFor(c => c.Description).MaximumLength(10).WithMessage("Description must not exceed 10 characters for testing purposes");
    }
}

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from Api Layer");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters for testing purposes");
    }
}
