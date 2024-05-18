using Jacustran.Domain.Products;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductListVm>>
{
    private readonly IAsyncRepository<Product, Guid> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IMapper mapper, IAsyncRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductListVm>> Handle(GetProductsQuery request, CancellationToken token)
    {
         return _mapper.Map<List<ProductListVm>>((await _productRepository.GetAllAsync(token)).OrderBy(p => p.Name));
    }
}
