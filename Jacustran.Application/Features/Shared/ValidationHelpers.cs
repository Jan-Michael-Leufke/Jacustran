namespace Jacustran.Application.Features.Shared;

public static class ValidationHelpers
{
    public static async Task<Result<TResponse>?> ValidateDtoAsync<TPatch, TResponse>(TPatch dtoToPatch, IValidator<TPatch> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(dtoToPatch, token);

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
