

using AutoMapper;
using FluentValidation;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.SharedKernel.Abstractions.MediatR;

public abstract class CommandHandlerBase<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    protected CommandHandlerBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public abstract Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);


    public virtual async Task<Result<TResponse>?> ValidateDtoAsync<TDto>(TDto dtoToValidate, IValidator<TDto> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(dtoToValidate, token);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error($"{e.ErrorCode}.{e.PropertyName} value: {e.AttemptedValue}", e.ErrorMessage)).ToArray();

            var result = ValidationResult<TResponse>.WithErrors(errors);

            return result;
        }

        return null;
    }
}

public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    protected CommandHandlerBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public abstract Task<Result> Handle(TCommand request, CancellationToken cancellationToken);


    public virtual async Task<Result?> ValidateDtoAsync<TDto>(TDto dtoToValidate, IValidator<TDto> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(dtoToValidate, token);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error($"{e.ErrorCode}.{e.PropertyName} value: {e.AttemptedValue}", e.ErrorMessage)).ToArray();

            var result = ValidationResult.WithErrors(errors);

            return result;
        }

        return null;
    }
}
