namespace Jacustran.SharedKernel.ValueObjects;

public class CityId : ValueObject<CityId>
{
    public Guid Value { get; }

    public CityId() => Value = Guid.NewGuid();
    public CityId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("City id cannot be empty", nameof(value));
        
        Value = value;
    }


    public static implicit operator Guid(CityId cityId) => cityId.Value;

    public static implicit operator CityId(Guid cityId) => new(cityId);

    protected override bool EqualsCore(CityId other) => Value == other.Value; 
    protected override int GetHashCodeCore() => Value.GetHashCode();

}
