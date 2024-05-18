using Jacustran.SharedKernel.Abstractions.Events;

namespace Jacustran.SharedKernel.Interfaces.Events;

public interface IHandler<T> where T : DomainEventBase
{
    Task HandleAsync(T domainEvent);
}
