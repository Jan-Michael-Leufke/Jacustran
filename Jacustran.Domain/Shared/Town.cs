namespace Jacustran.Domain.Shared;

public class Town : Location
{
    public Town(string name, string description, string imageUrl, int population) : base(name, description, imageUrl)
    {
        Population = population;
    }

    public Town(Guid id, string name, string description, string imageUrl, int population) : this(name, description, imageUrl, population)
    {
        Id = id;
    }

    public int Population { get; set; } 

    public ICollection<Spot> Spots { get; set; } = new List<Spot>();

}
