using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jacustran.Domain.Responses;


public class Result
{
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorDetails { get; set; }

    public Result(bool isSuccess, string? message, string? errorCode, string? errorDetails)
    {
        IsSuccess = isSuccess;
        Message = message;
        ErrorCode = errorCode;
        ErrorDetails = errorDetails;
    }

    public static Result Success(string? message = null)
    {
        return new Result(true, message, null, null);
    }
    public static Result Failure(string errorCode, string? message = null, string? errorDetails = null)
    {
        return new Result(false, message, errorCode, errorDetails);
    }
}


public class Result<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorDetails { get; set; }
    public Result(T data, bool isSuccess, string? message, string? errorCode, string? errorDetails)
    {
        Data = data;
        IsSuccess = isSuccess;
        Message = message;
        ErrorCode = errorCode;
        ErrorDetails = errorDetails;
    }
    public static Result<T> Success(T data, string? message = null)
    {
        return new Result<T>(data, true, message, null, null);
    }
    public static Result<T> Failure(string errorCode, string? message = null, string? errorDetails = null)
    {
        return new Result<T>(default!, false, message, errorCode, errorDetails);
    }
    public static Result<T> Failure(string errorCode, T data, string? message = null, string? errorDetails = null)
    {
        return new Result<T>(data, false, message, errorCode, errorDetails);
    }
    public static Result<T> Failure(string errorCode, T data, string? message = null)
    {
        return new Result<T>(data, false, message, errorCode, null);
    }
    public static Result<T> Failure(string errorCode)
    {
        return new Result<T>(default!, false, null, errorCode, null);
    }
    public static Result<T> Failure(string errorCode, string? message = null)
    {
        return new Result<T>(default!, false, message, errorCode, null);
    }


    //public static implicit operator Result<T>(Result result)
    //{
    //    return new Result<T>(default!, result.IsSuccess, result.Message, result.ErrorCode, result.ErrorDetails);
    //}
    //public static implicit operator Result(Result<T> result)
    //{
    //    return new Result(result.Data, result.IsSuccess, result.Message, result.ErrorCode, result.Error)
    //}
}