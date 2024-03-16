namespace Jacustran.Domain.Cities;

public class City(string name) : Town(name)
{
    public City() : this(string.Empty) { }

    public bool IsImportantCity { get; set; }


}
