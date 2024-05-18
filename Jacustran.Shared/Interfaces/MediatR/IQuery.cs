namespace Jacustran.SharedKernel.Interfaces.MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
