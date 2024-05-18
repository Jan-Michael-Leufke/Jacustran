namespace Jacustran.SharedKernel.Responses;

public class Result<T>
{
    public T? Data { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(T? data, bool isSuccess, Error error)
    {
        Data = data;
        IsSuccess = isSuccess;
        Error = error;
    }


    public static Result<T> Success(T data) => new(data, true, Error.None);
    public static Result<T> Failure(Error error) => new(default!, false, error);



    public static implicit operator Result<T>(Result result) => new(default, result.IsSuccess, result.Error);

    public static implicit operator Result(Result<T> result) => result.IsSuccess ? Result.Success() : Result.Failure(result.Error);

}
