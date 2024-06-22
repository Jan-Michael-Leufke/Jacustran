namespace Jacustran.SharedKernel.Interfaces.Events;

public interface IHandle<TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent, CancellationToken cancellationToken);
}
