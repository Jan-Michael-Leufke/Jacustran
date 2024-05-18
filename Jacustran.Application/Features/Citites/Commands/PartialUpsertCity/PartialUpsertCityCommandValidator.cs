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
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.ImageUrl)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleForEach(p => p.Spots).SetValidator(new PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator());
    }
}

public class PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator : AbstractValidator<PartialUpsertCityPatchDto_PartialUpsertSpotsDto>
{
    public PartialUpsertCityPatchDto_PartialUpsertSpotsDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.ImageUrl)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
    }
}   

