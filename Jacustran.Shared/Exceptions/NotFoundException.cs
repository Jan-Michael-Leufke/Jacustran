namespace Jacustran.Shared.Exceptions;

public class NotFoundException(Guid id, string message) : Exception(message)
{
    public Guid Id { get; set; } = id;
}
