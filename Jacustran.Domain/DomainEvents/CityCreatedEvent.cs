using Jacustran.SharedKernel.Abstractions.Events;
using Jacustran.SharedKernel.Interfaces.Events;

namespace Jacustran.Domain.Events;

public class CityCreatedEvent : DomainEventBase, IDomainEvent
{
    public City.City CreatedCity { get; set; }

    public DateTime DateOccurred { get; private set; } 

    public CityCreatedEvent(City.City city, DateTime dateCreated)
    {
        CreatedCity = city;
        DateOccurred = dateCreated;
    }

    public CityCreatedEvent(City.City city) : this (city, DateTime.UtcNow) { }
}
