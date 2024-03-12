using Jacustran.Domain.Shared;

namespace Jacustran.Domain.Entities;

public class Product(string name) : EntityBase
{
    public Product() :this(string.Empty) { }

    public string Name { get; set; } = name;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }

    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }
}

