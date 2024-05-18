using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandHandler : ICommandHandler<CreateCityCommand, CreateCityResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    private readonly IMapper _mapper;
    //private readonly IValidator<CreateCityCommand> _validator;

    public CreateCityCommandHandler
       (IAsyncRepository<City, Guid> cityRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IValidator<CreateCityCommand> validator)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        //_validator = validator;
    }

    public async Task<Result<CreateCityResponse>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {        
        //var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        
        //if (!validationResult.IsValid) return CityErrors.FluentValidationError.ToResult();
       
        var newCityEntity = _mapper.Map<City>(command);

        _cityRepository.Add(newCityEntity);
 
        //await _unitOfWork.SaveChangesAsync(cancellationToken);
        var result = await _unitOfWork.TrySaveChangesAsync(cancellationToken);
        
        //return Result<Guid>.Success(newCityEntity.Id);
        return result.IsSuccess ? Result<CreateCityResponse>.Success(new CreateCityResponse(newCityEntity.Id)) : 
            Result<CreateCityResponse>.Failure(new("SQL.Error", "Sql Error from App-Layer"));
    }
}
