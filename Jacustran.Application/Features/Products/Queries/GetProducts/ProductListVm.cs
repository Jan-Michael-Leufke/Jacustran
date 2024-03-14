namespace Jacustran.Application.Features.Products.Queries.GetProducts;

public class ProductListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }

}