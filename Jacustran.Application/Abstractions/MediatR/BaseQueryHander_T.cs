namespace Jacustran.Application.Abstractions.MediatR;

public abstract class BaseQueryHandler<T> where T : EntityBase
{
    protected readonly IMapper _mapper;
    protected readonly IAsyncRepository<T> _asyncRepository;
    protected BaseQueryHandler(IMapper mapper, IAsyncRepository<T> asyncRepository)
    {
        _mapper = mapper;
        _asyncRepository = asyncRepository;
    }
}