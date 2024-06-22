
using Jacustran.Domain.DomainServices;
using Jacustran.Domain.Events;
using Jacustran.Domain.ValueObjects;
using Jacustran.SharedKernel.Interfaces.Entities;

namespace Jacustran.Domain.City;

public class City : Town
{
    private City() { }

    public City(LocationName name, string description, string imageUrl, int population, bool isImportantCity)
        : base(name, description, imageUrl, population)
    {
        IsImportantCity = isImportantCity;
        Name = name;
        DomainEvents.Add(new CityCreatedEvent(this, DateTime.Now));
    }



    public City(Guid id, LocationName name, string description, string imageUrl, int population, bool isImportantCity)
        : this(name, description, imageUrl, population, isImportantCity)
    {
        Id = id;
    }

    public bool IsImportantCity { get;  set; }


    public static DomainValidationResult<City> Create(LocationName name, string description, string imageUrl, int population, bool isImportantCity)
    {
        var city = new City(name, description, imageUrl, population, isImportantCity);

        var validationResult = ServiceLocator.GetService<IValidator<City>>().Validate(city);

        return validationResult.IsValid ? DomainValidationResult<City>.Success(city)
                                        : DomainValidationResult<City>.Failure(new ValidationException(validationResult.Errors));
    }


}

