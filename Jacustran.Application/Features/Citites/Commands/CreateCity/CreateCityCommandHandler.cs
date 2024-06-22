using Jacustran.Domain.Events;
using Jacustran.Domain.ValueObjects;
using Jacustran.SharedKernel.Interfaces.Persistence;
using Jacustran.Domain.Abstractions;
using FluentValidation.Results;
using System.Security.Cryptography.X509Certificates;

namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandHandler : CommandHandlerBase<CreateCityCommand, CreateCityResponse>
{
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    //private readonly IMapper _mapper;
    //private readonly IValidator<CreateCityCommand> _validator;

    public CreateCityCommandHandler
       (IAsyncRepository<City, Guid> cityRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IValidator<CreateCityCommand> validator) : base(unitOfWork, mapper)
    {
        _cityRepository = cityRepository;
        //_validator = validator;
    }

    public override async Task<Result<CreateCityResponse>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {
        var cityNameOrValidationErrors = LocationName.Create(command.Name);         

        if(IsDomainValidationResultsFaulted(out var validationResult, cityNameOrValidationErrors)) return validationResult!;

        var city = City.Create(cityNameOrValidationErrors.Data!, command.Description, command.ImageUrl, command.Population, command.IsImportantCity);


        if (command.Spots is not null)
        {
            foreach (var spotDto in command.Spots)
            {
                var spotName = LocationName.Create(spotDto.Name);

                if(IsDomainValidationResultsFaulted(out var result, spotName)) return result!;

                city.Data!.Spots.Add(new Spot(spotName.Data!, spotDto.Description, spotDto.ImageUrl, spotDto.StarRating));
            }
        }


        _cityRepository.Add(city.Data!);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CreateCityResponse>.Success(new(city.Data!.Id));
    }



}

