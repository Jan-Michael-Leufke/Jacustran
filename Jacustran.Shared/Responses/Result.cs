using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jacustran.SharedKernel.Responses;

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





public struct ValueResult
{
    public ResultState State { get; }
    public bool IsSuccess => State == ResultState.Success;
    public bool IsFaulted => !IsSuccess;


    public Exception? Exception { get; }

    private ValueResult(ResultState state, Exception? exception)
    {
        if (state == ResultState.Faulted && exception is null) throw new InvalidOperationException("Exception must be provided when state is Faulted");
        if (state == ResultState.Success && exception is not null) throw new InvalidOperationException("Exception must be null when state is Success");

        State = state;
        Exception = exception;
    }

    public static ValueResult Success() => new(ResultState.Success, null);
    public static ValueResult Failure(Exception exception) => new(ResultState.Faulted, exception);



    public void Match(Action Succ, Action<Exception> Fail)
    {
        if (IsSuccess) Succ();
        else Fail(Exception!);
    }

}


public class DomainResult
{
    public ResultState State { get; }
    public bool IsSuccess => State == ResultState.Success;
    public bool IsFaulted => !IsSuccess;

    protected Exception? _exception;
    public virtual Exception? Exception { get; }

    protected DomainResult(ResultState state, Exception? exception)
    {
        if (state == ResultState.Faulted && exception is null) throw new InvalidOperationException("Exception must be provided when state is Faulted");
        if (state == ResultState.Success && exception is not null) throw new InvalidOperationException("Exception must be null when state is Success");

        State = state;
        _exception = exception;
    }

    
    public static DomainResult Success() => new(ResultState.Success, null);
    public static DomainResult Failure(Exception exception) => new(ResultState.Faulted, exception);



    
    public virtual void Match(Action Succ, Action<Exception> Fail)
    {
        if (IsSuccess) Succ();
        else Fail(Exception!);
    }

    
}



public class DomainValidationResult : DomainResult
{
    public override Exception? Exception
    {
        get
        {
            if (_exception is ValidationException ex) return ex;
            if(_exception is null) return null;

            throw new InvalidOperationException("Exception must be of type ValidationException");
        } 
    }

    protected DomainValidationResult(ResultState state, ValidationException? exception) : base(state, exception) { }


    public static DomainValidationResult Success() => new(ResultState.Success, null);
    public static DomainValidationResult Failure(ValidationException exception) => new(ResultState.Faulted, exception);

  
}
