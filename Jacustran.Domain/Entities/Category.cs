using Jacustran.Domain.Shared;

namespace Jacustran.Domain.Entities;

public class Category(string name) : EntityBase  
{
    public Category() : this(string.Empty) { }  

    public string Name { get; set; } = name;
    public string? Description { get; set; }

    public ICollection<Product>? Products { get; set; } = new List<Product>();
}
