using Jacustran.Domain.Responses;
using System.Net.NetworkInformation;

namespace Jacustran.Domain.Errors;

public record Error(string errorCode, string description)
{   
    public string ErrorCode { get; } = errorCode;
    public string ErrorMessage { get; } = description;

    public static readonly Error None = new Error("Error.None", "No error");
    public static readonly Error Empty = new Error(string.Empty, string.Empty);

    public static implicit operator Result(Error error) => Result.Failure(error.ErrorCode, error.ErrorMessage);

    public Result ToResult()  => Result.Failure(this.errorCode, this.ErrorMessage); 
}