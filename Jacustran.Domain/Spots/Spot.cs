using Jacustran.Domain.ValueObjects;

namespace Jacustran.Domain.Spots;

public class Spot : Location
{
    private Spot() { }

    public Spot(LocationName name, string description, string imageUrl, StarRating rating) : base(name, description, imageUrl)
    {
        Rating = rating;
    }

    public Spot(Guid id, LocationName name, string description, string imageUrl, StarRating rating) : this(name, description, imageUrl, rating)
    {
        Id = id;
    }

    public StarRating Rating { get;  set; }

    public Town? Town { get; set; }
    public Guid? TownId { get; set; }

}
