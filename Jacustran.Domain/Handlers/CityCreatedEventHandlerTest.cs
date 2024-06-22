using Jacustran.Domain.Events;
using Jacustran.SharedKernel.Interfaces.Events;

namespace Jacustran.Domain.Handlers;

public class CityCreatedEventHandlerTest : IHandler<CityCreatedEvent>
{
    public Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{notification.CreatedCity.Name} was dispatched on {notification.DateOccurred}");

        return Task.CompletedTask;
    }

    
}
