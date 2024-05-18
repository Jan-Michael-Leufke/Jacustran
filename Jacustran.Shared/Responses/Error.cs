namespace Jacustran.SharedKernel.Responses;

public record Error(string errorCode, string? description = null)
{
    public static readonly Error None = new Error(string.Empty);


    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
    public Result<T> ToResult<T>() => Result<T>.Failure(this);
}