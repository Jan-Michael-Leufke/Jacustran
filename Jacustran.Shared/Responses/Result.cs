namespace Jacustran.Shared.Responses;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new InvalidOperationException("Invalid Error Type");

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

}


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