using Jacustran.Domain.Products;

namespace Jacustran.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductListVm>>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductListVm>> Handle(GetProductsQuery request, CancellationToken token)
    {
         return _mapper.Map<List<ProductListVm>>((await _productRepository.GetAllAsync(token)).OrderBy(p => p.Name));
    }
}
