
namespace Jacustran.Domain.Cities;

public class City : Town
{
    public City(string name, string description, string imageUrl, int population, bool isImportantCity)
        : base(name, description, imageUrl, population)
    {
        IsImportantCity = isImportantCity;
    }

    public City(Guid id, string name, string description, string imageUrl, int population, bool isImportantCity)
        : this(name, description, imageUrl, population, isImportantCity)
    {
        Id = id;
    }

    public bool IsImportantCity { get; private set; }



}


