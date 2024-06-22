
using Jacustran.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jacustran.Domain.Shared;

public class Location : AggregateRoot<Guid>
{
    protected Location() { }

    public Location(LocationName name, string description, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be empty", nameof(description));
        if (string.IsNullOrWhiteSpace(imageUrl)) throw new ArgumentException("ImageUrl cannot be empty", nameof(imageUrl));

        Name = name ?? throw new ArgumentException("Name cannot be empty", nameof(name));
        Description = description;
        ImageUrl = imageUrl;
    }

    public Location(Guid id, LocationName name, string description, string imageUrl) : this(name, description, imageUrl)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(id));
        if (id == default) throw new ArgumentException("Id cannot be default", nameof(id));

        Id = id;
    }



    //protected string _locationName;


    //public LocationName Name
    //{
    //    get => LocationName.Create(_locationName).Data!;
    //    set => _locationName = value.Value;
    //}

    public LocationName Name { get;  set; }


    //public string Name { get;  set; } 
    public string Description { get;  set; } 
    public string ImageUrl { get;  set; }



    //public Location(string name, string description, string imageUrl)
    //{
    //    if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
    //    if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be empty", nameof(description));
    //    if (string.IsNullOrWhiteSpace(imageUrl)) throw new ArgumentException("ImageUrl cannot be empty", nameof(imageUrl));

    //    Name = name;
    //    Description = description;
    //    ImageUrl = imageUrl;
    //}

    //public Location(Guid id, string name, string description, string imageUrl) : this(name, description, imageUrl)
    //{
    //    if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(id));
    //    if (id == default) throw new ArgumentException("Id cannot be default", nameof(id));

    //    Id = id;
    //}
    
}
