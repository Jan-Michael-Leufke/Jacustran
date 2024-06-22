namespace Jacustran.Domain.ValueObjects;

public class Population : ValueObject<Population>
{
    public Population(long value)
    {
        if (value < 0) throw new ArgumentException("Population cannot be negative", nameof(value));

        Value = value;
    }

    public long Value { get; }

    protected override bool EqualsCore(Population other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();

}
