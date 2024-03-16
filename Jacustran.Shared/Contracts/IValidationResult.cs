namespace Jacustran.Shared.Contracts;

public interface IValidationResult
{
    public static readonly Error ValidationError = new Error("Validation error", "The request is invalid");
    public Error[] ValidationErrors { get; } 
}
