namespace Jacustran.Domain.ValueObjects;

public class SpotId : ValueObject<SpotId>
{
    public Guid Value { get; }

    public SpotId() => Value = Guid.NewGuid();

    public SpotId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Spot id cannot be empty", nameof(value));

        Value = value;
    }

    public static implicit operator Guid(SpotId spotId) => spotId.Value;

    public static implicit operator SpotId(Guid spotId) => new(spotId);

    protected override bool EqualsCore(SpotId other) => Value == other.Value;   
    protected override int GetHashCodeCore() => Value.GetHashCode();
}
