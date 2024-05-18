
namespace Jacustran.Application.Abstractions.MediatR;

public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    protected readonly IMapper _mapper;
    protected QueryHandlerBase(IMapper mapper) => _mapper = mapper;
    

    public abstract Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}

