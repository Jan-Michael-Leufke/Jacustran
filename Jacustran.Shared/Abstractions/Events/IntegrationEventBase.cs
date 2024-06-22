namespace Jacustran.SharedKernel.Abstractions.Events;


public class IntegrationEventBase : INotification
{
    public DateTimeOffset DateTriggered { get; protected set; } = DateTimeOffset.UtcNow;

    public string EventName => GetType().Name;
}

