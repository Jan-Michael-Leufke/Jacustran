namespace Jacustran.SharedKernel.Exceptions;
public abstract class BaseDomainException : Exception

{
    protected BaseDomainException(string message) : base(message)
    {
    }

    protected BaseDomainException(string message, Exception innerException) : base(message, innerException)
    {
    }

    
}
