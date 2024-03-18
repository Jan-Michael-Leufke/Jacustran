namespace Jacustran.Domain.Shared;

public class Town(string name) : Location(name)
{
    public Town() : this(string.Empty) { }

    public int Population { get; set; }


    public ICollection<Spot> Spots { get; set; } = new List<Spot>();


}
