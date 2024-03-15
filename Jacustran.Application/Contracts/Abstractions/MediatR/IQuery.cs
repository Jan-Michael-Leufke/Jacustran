

namespace Jacustran.Application.Contracts.Abstractions.MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }   
