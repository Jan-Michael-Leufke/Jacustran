using Jacustran.Domain.Entity.Shared;

namespace Jacustran.Domain.Entity.Entities;

public class City(string name) : Town(name)
{
    public City() : this(string.Empty) { }

    public bool IsImportantCity { get; set; }


}
