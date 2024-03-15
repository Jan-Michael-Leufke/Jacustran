using Jacustran.Application.Features.Products.Queries.GetProducts;
using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Application.Profiles;

public class ProductMappingsProfile : Profile
{
    public ProductMappingsProfile()
    {
        CreateMap<Product, ProductListVm>().ReverseMap();
    }
}

