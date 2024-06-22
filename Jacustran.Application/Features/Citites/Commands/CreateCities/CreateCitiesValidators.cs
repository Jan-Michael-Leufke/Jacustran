using Jacustran.Application.Features.Citites.Commands.CreateCity;

namespace Jacustran.Application.Features.Citites.Commands.CreateCities;



public class CreateCitiesRequestValidator : AbstractValidator<CreateCitiesRequest>
{
    public CreateCitiesRequestValidator()
    {
        RuleFor(c => c.Cities).NotEmpty().WithMessage("Requests are required from CreateCitiesRequestValidator");

        RuleForEach(c => c.Cities).SetValidator(new CreateCitiesRequestDtoValidator());
    }

}

public class CreateCitiesRequestDtoValidator : AbstractValidator<CreateCitiesRequestDto>
{
    public CreateCitiesRequestDtoValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoRequestBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new CreateCities_CreateSpotsDtoValidator());
    }
}




public class CreateCitiesCommandValidator : AbstractValidator<CreateCitiesCommand>
{
    public CreateCitiesCommandValidator()
    {
        RuleFor(c => c.Cities).NotEmpty().WithMessage("Requests are required from CreateCitiesCommandValidator");
        RuleForEach(c => c.Cities).SetValidator(new CreatecitiesCommandInnerDtoValidator());
    }
}

public class CreatecitiesCommandInnerDtoValidator : AbstractValidator<CreateCitiesCommandInnerDto>
{
    public CreatecitiesCommandInnerDtoValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new CreateCities_CreateSpotsDtoValidator());
    }
}




public class CreateCities_CreateSpotsDtoValidator : AbstractValidator<CreateCities_CreateSpotsDto>
{
    public CreateCities_CreateSpotsDtoValidator()
    {
        RuleFor(c => c).SetValidator(new SpotForManipulationDtoBaseValidator());
    }
}


