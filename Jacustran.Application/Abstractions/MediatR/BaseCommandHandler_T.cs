namespace Jacustran.Application.Abstractions.MediatR;

public abstract class BaseCommandHandler<T> where T : EntityBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    protected readonly IAsyncRepository<T> _asyncRepository;
    protected BaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAsyncRepository<T> asyncRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _asyncRepository = asyncRepository;
    }
}
