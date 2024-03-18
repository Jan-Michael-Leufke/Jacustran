namespace Jacustran.Application.Behaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if (!_validators.Any()) return await next();

        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults = new List<ValidationResult>();

        Error[] errors = _validators.SelectMany(v => v.Validate(validationContext).Errors)
                                   .Where(vf => vf is not null)
                                   .Select(f => new Error($"{f.ErrorCode}.{f.PropertyName}", f.ErrorMessage))
                                   .ToArray();

        if (!errors.Any()) return await next();

        if (typeof(TResponse) == typeof(Result)) return (ValidationResult.WithErrors(errors) as TResponse)!;


        var validationResult = typeof(ValidationResult<>)
           .GetGenericTypeDefinition()
           .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
           .GetMethod(nameof(ValidationResult.WithErrors))?.Invoke(null, new object?[] { errors });

        return (TResponse)validationResult!;
    }

}
