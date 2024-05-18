namespace Jacustran.Domain.Spots;

public class Spot : Location
{
    private Spot() { }

    public Spot(string name, string description, string imageUrl, StarRating rating) : base(name, description, imageUrl)
    {
        Rating = rating;
    }

    public Spot(Guid id, string name, string description, string imageUrl, StarRating rating) : this(name, description, imageUrl, rating)
    {
        Id = id;
    }

    public StarRating Rating { get; private set; }

    public Town? Town { get; set; }
    public Guid? TownId { get; set; }

}
