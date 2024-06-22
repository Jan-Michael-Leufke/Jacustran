using Jacustran.Domain.ValueObjects;

namespace Jacustran.Domain.Shared;

public class Town : Location
{
    protected Town() { }

    public Town(LocationName name, string description, string imageUrl, int population) : base(name, description, imageUrl)
    {
        if (population <= 0) throw new ArgumentException("Population cannot be less than or equal to zero", nameof(population));

        Population = population;
    }

    public Town(Guid id, LocationName name, string description, string imageUrl, int population) : this(name, description, imageUrl, population)
    {
        Id = id;
    }

    public int Population { get; set; }

    //public Population Population { get;  private set; }

    public ICollection<Spot> Spots { get; set; } = new List<Spot>();

    


}
