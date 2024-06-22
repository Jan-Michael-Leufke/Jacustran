using Jacustran.Domain.Abstractions;

namespace Jacustran.Domain.ValueObjects;

public class CityName : ValidatableValueObject<CityName>
{
    private CityName(string value) => Value = value;
    

    public static DomainValidationResult<CityName> Create(string value)
    {
        var cityName = new CityName(value);

        return cityName.FluentValidate();
    }

    public string Value { get; }

    protected override bool EqualsCore(CityName other) => Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);

    protected override int GetHashCodeCore() => Value.GetHashCode();  
}




public class CityNameValidator : AbstractValidator<CityName>
{
    public CityNameValidator()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Value).MaximumLength(5).WithMessage("Name cannot be longer than 5 characters");
    }
}


