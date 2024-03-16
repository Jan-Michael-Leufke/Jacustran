using Jacustran.Application.Features.Products.Queries.GetProducts;

namespace Jacustran.Application.Profiles;

public class ProductMappingsProfile : Profile
{
    public ProductMappingsProfile()
    {
        CreateMap<Product, ProductListVm>().ReverseMap();
    }
}

