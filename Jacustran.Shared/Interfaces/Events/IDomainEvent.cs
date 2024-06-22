namespace Jacustran.SharedKernel.Interfaces.Events;

public interface IDomainEvent : INotification 
{
    DateTime DateOccurred { get; }
}
