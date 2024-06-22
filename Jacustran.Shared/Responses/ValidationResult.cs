namespace Jacustran.SharedKernel.Responses;

public class ValidationResult : Result, IValidationResult
{  
    private ValidationResult(Error[] validationErrors) 
        : base(false, IValidationResult.ValidationError) => ValidationErrors = validationErrors;

    public Error[] ValidationErrors { get; }

    public static ValidationResult WithErrors(Error[] validationErrors) => new(validationErrors);
}


public class ValidationResult<T> : Result<T>, IValidationResult
{
    private ValidationResult(Error[] validationErrors) 
        : base(default, false, IValidationResult.ValidationError) => ValidationErrors = validationErrors;



    public Error[] ValidationErrors { get; }

    public static ValidationResult<T> WithErrors(Error[] validationErrors) => new(validationErrors);

    public static ValidationResult<T> WithErrorsFromFluentValidationResult(FluentValidation.Results.ValidationResult fluentValidationResult) =>
        new(fluentValidationResult.Errors
            .Where(f => f is not null)
            .Select(f => new Error($"{f.ErrorCode}.{f.PropertyName} value: {f.AttemptedValue}", f.ErrorMessage)).ToArray());
}

