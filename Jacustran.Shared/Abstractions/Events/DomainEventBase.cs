namespace Jacustran.SharedKernel.Abstractions.Events;

public class DomainEventBase : INotification
{
    public DateTimeOffset DateTriggered { get; protected set; } = DateTimeOffset.UtcNow;
}
