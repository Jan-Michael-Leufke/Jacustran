using FluentValidation;

namespace Jacustran.Application.Features.Citites.Commands.UpsertCity;

public class UpsertCityCommandValidator : AbstractValidator<UpsertCityCommand>
{
    public UpsertCityCommandValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new SpotForManipulationDtoBaseValidator());
    }

}

public class UpsertCityRequestValidator : AbstractValidator<UpsertCityRequest>
{
    public UpsertCityRequestValidator()
    {
        RuleFor(c => c.Body).SetValidator(new CityForManipulationDtoBaseValidator());

        RuleForEach(c => c.Body.Spots).SetValidator(new UpsertCity_UpsertSpotsDtoValidator());
    }
}

public class UpsertCity_UpsertSpotsDtoValidator : AbstractValidator<UpsertCity_UpsertSpotsDto>
{
    public UpsertCity_UpsertSpotsDtoValidator()
    {
        RuleFor(s => s).SetValidator(new SpotForManipulationDtoBaseValidator());

    }

}
