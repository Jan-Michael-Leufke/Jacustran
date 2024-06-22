
namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

public class PartialUpsertCityCommandValidator : AbstractValidator<PartialUpsertCityCommand>
{
    public PartialUpsertCityCommandValidator()
    {
        RuleFor(p => p.CityId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");

        RuleFor(p => p.PatchDocument)
            .NotNull().WithMessage("{PropertyName} is required.");

    }
}


public class PartialUpsertCityPatchDtoValidator : AbstractValidator<PartialUpsertCityPatchDto>
{
    public PartialUpsertCityPatchDtoValidator()
    {
        RuleFor(c => c).SetValidator(new CityForManipulationDtoBaseValidator());

        RuleForEach(c => c.Spots).SetValidator(new PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator());
    }
}

public class PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator : AbstractValidator<PartialUpsertCityPatchDto_PartialUpsertSpotsDto>
{
    public PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator()
    {
        RuleFor(s => s).SetValidator(new SpotForManipulationDtoBaseValidator());
    }
}   

