﻿

namespace Jacustran.Application.Contracts.Abstractions.MediatR;

public interface ICommand : IRequest<Result>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { } 

public interface IBaseCommand { }