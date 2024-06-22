using Jacustran.SharedKernel.Abstractions.Events;

namespace Jacustran.SharedKernel.Interfaces.Events;

public interface IHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : DomainEventBase
{
    //Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken);
}
