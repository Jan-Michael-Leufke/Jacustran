namespace Jacustran.Application.Contracts.Application.MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
