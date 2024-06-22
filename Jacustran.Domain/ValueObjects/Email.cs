namespace Jacustran.Domain.ValueObjects;

public class Email : ValueObject<Email>
{
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Email cannot be empty", nameof(value));

        Value = value;
    }     

    public string Value { get; }

    protected override bool EqualsCore(Email other) => Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);

    protected override int GetHashCodeCore() => Value.GetHashCode();
}
