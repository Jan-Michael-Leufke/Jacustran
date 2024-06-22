namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoRequestBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new CreateCity_CreateSpotsDtoValidator());
    }

}


public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new SpotForManipulationDtoBaseValidator());
    }
}




public class CreateCity_CreateSpotsDtoValidator : AbstractValidator<CreateCity_CreateSpotsDto>
{
    public CreateCity_CreateSpotsDtoValidator()
    {
        RuleFor(c => c).SetValidator(new SpotForManipulationDtoBaseValidator());
    }
}



