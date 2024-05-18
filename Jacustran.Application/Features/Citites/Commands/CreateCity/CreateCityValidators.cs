namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from command in App Layer");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 10 characters for testing purposes");   
        RuleForEach(c => c.Spots).SetValidator(new CreateCity_CreateSpotsDtoValidator());
    }
}

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from request in Api Layer");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
    }

}

public class CreateCity_CreateSpotsDtoValidator : AbstractValidator<CreateCity_CreateSpotsDto>
{
    public CreateCity_CreateSpotsDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from CreateCity_CreateSpotsDtoValidator");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
    }
}

