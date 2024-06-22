using Jacustran.SharedKernel.Abstractions.Events;

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




public readonly struct ValueResult<T>
{
    public ResultState State { get; }
    public bool IsSuccess => State == ResultState.Success;
    public bool IsFaulted => !IsSuccess;

    public T? Data { get; }
    public Exception? Exception { get; }

    private ValueResult(T? data, ResultState state, Exception? exception)
    {
        if(state == ResultState.Faulted && exception is null) throw new InvalidOperationException("Exception must be provided when state is Faulted");
        if(state == ResultState.Success && exception is not null) throw new InvalidOperationException("Exception must be null when state is Success");

        Data = data;
        State = state;
        Exception = exception;
    }


    public static ValueResult<T> Success(T data) => new(data, ResultState.Success, null);
    public static ValueResult<T> Failure(Exception exception) => new(default!, ResultState.Faulted, exception);


    public R Match<R>(Func<T?, R> SuccessPath, Func<Exception, R> FailurePath)
    {
        return IsSuccess ? SuccessPath(Data) : FailurePath(Exception!);
    }

    public void Match(Action<T?> Succ, Action<Exception> Fail)
    {
        if (IsSuccess) Succ(Data);
        else Fail(Exception!);
    }

    public static implicit operator ValueResult<T>(ValueResult result) => new(default, result.State, result.Exception);

    public static implicit operator ValueResult(ValueResult<T> result) => result.State is ResultState.Success ? 
                                                                                          ValueResult.Success() :
                                                                                          ValueResult.Failure(result.Exception!);

    public static implicit operator ValueResult<T>(T data) => Success(data);

}






public class DomainResult<T> 
{
    public ResultState State { get; }
    public bool IsSuccess => State == ResultState.Success;
    public bool IsFaulted => !IsSuccess;

    public T? Data { get; }
    public Exception? Exception { get; }

    private DomainResult(T? data, ResultState state, Exception? exception)
    {
        if (state == ResultState.Faulted && exception is null) throw new InvalidOperationException("Exception must be provided when state is Faulted");
        if (state == ResultState.Success && exception is not null) throw new InvalidOperationException("Exception must be null when state is Success");

        Data = data;
        State = state;
        Exception = exception;
    }


    public static DomainResult<T> Success(T data) => new(data, ResultState.Success, null);
    public static DomainResult<T> Failure(Exception exception) => new(default!, ResultState.Faulted, exception);


    public R Match<R>(Func<T?, R> SuccessPath, Func<Exception, R> FailurePath)
    {
        return IsSuccess ? SuccessPath(Data) : FailurePath(Exception!);
    }

    public void Match(Action<T?> Succ, Action<Exception> Fail)
    {
        if (IsSuccess) Succ(Data);
        else Fail(Exception!);
    }

    public static implicit operator DomainResult<T>(DomainResult result) => new(default, result.State, result.Exception);

    public static implicit operator DomainResult(DomainResult<T> result) => result.State is ResultState.Success ?
                                                                                          DomainResult.Success() :
                                                                                          DomainResult.Failure(result.Exception!);

    public static implicit operator DomainResult<T>(T data) => Success(data);

}





public class DomainValidationResult<T> : DomainValidationResult
{

    public T? Data { get; }


    private DomainValidationResult(T? data, ResultState state, ValidationException? exception) : base(state, exception)
    {
        Data = data;
    }


    public static DomainValidationResult<T> Success(T data) => 
        new(data ?? throw new InvalidOperationException("data must be provided if state is success!"), ResultState.Success, null);
    public new static DomainValidationResult<T> Failure(ValidationException exception) => new(default!, ResultState.Faulted, exception);


    //public R Match<R>(Func<T?, R> SuccessPath, Func<Exception, R> FailurePath)
    //{
    //    return IsSuccess ? SuccessPath(Data) : FailurePath(Exception!); ;
    //}



    public void Match(Action<T> Succ, Action<ValidationException> Fail)
    {
        if (IsSuccess) Succ(Data!);
        else Fail((ValidationException)Exception!);
    }

    //public static implicit operator DomainResult<T>(DomainResult result) => new(default, result.State, result.Exception);

    //public static implicit operator DomainResult(DomainResult<T> result) => result.State is ResultState.Success ? 
    //                                                                                      DomainResult.Success() :
    //                                                                                      DomainResult.Failure(result.Exception!);

    public static implicit operator DomainValidationResult<T>(T data) => Success(data);

}

