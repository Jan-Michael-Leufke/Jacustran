using Jacustran.Domain.Abstractions;

namespace Jacustran.Domain.ValueObjects;


public class LocationName : ValidatableValueObject<LocationName>
{
    private LocationName() { }

    private LocationName(string value) => Value = value;


    public static DomainValidationResult<LocationName> Create(string value)
    {
        var LocationName = new LocationName(value);

        return LocationName.FluentValidate();
    }
   
    public string Value { get; }

    protected override bool EqualsCore(LocationName other) => Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);

    protected override int GetHashCodeCore() => Value.GetHashCode();
}




public class LocationNameValidator : AbstractValidator<LocationName>
{
    public LocationNameValidator()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Value).MaximumLength(50).WithMessage("Name cannot be longer than 5 characters");
    }
}


