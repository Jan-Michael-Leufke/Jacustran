
namespace Jacustran.Domain.Shared;

public class Location : AggregateRoot<Guid>
{
    protected Location() { }

    public Location(string name, string description, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be empty", nameof(description));
        if (string.IsNullOrWhiteSpace(imageUrl)) throw new ArgumentException("ImageUrl cannot be empty", nameof(imageUrl));

        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public Location(Guid id, string name, string description, string imageUrl) : this(name, description, imageUrl)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(id));
        if (id == default) throw new ArgumentException("Id cannot be default", nameof(id));

        Id = id;
    }


    public string Name { get; private set; } 
    public string Description { get; private set; } 
    public string ImageUrl { get; private set; } 

}
