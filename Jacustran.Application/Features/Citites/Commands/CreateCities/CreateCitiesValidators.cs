using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Features.Citites.Commands.CreateCities;


public class CreateCitiesCommandValidator : AbstractValidator<CreateCitiesCommand>
{
    public CreateCitiesCommandValidator()
    {
        RuleFor(c => c.Requests).NotEmpty().WithMessage("Requests are required from CreateCitiesCommandValidator");
        RuleForEach(c => c.Requests).SetValidator(new CreatecitiesCommandInnerDtoValidator());
    }
}

public class CreatecitiesCommandInnerDtoValidator : AbstractValidator<CreateCitiesCommandInnerDto>
{
    public CreatecitiesCommandInnerDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from CreatecitiesCommandInnerDtoValidator");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
        RuleForEach(c => c.Spots).SetValidator(new CreateCities_CreateSpotsDtoValidator());
    }
}

public class CreateCitiesRequestValidator : AbstractValidator<CreateCitiesRequest>
{
    public CreateCitiesRequestValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from CreateCitiesRequestValidator ");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
        RuleForEach(c => c.Spots).SetValidator(new CreateCities_CreateSpotsDtoValidator());
    }

}

public class CreateCities_CreateSpotsDtoValidator : AbstractValidator<CreateCities_CreateSpotsDto>
{
    public CreateCities_CreateSpotsDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required from CreateCity_CreateSpotsDtoValidator");
        RuleFor(c => c.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
    }
}


