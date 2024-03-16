namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandHandler : ICommandHandler<CreateCityCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncRepository<City> _cityRepository;
    private readonly IMapper _mapper;
    //private readonly IValidator<CreateCityCommand> _validator;

    public CreateCityCommandHandler
       (IAsyncRepository<City> cityRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IValidator<CreateCityCommand> validator)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        //_validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {        
        //var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        
        //if (!validationResult.IsValid) return CityErrors.FluentValidationError.ToResult();
       
        var newCityEntity = _mapper.Map<City>(command);

        _cityRepository.Add(newCityEntity);
 
        //await _unitOfWork.SaveChangesAsync(cancellationToken);
        var result = await _unitOfWork.TrySaveChangesAsync(cancellationToken);
        
        //return Result<Guid>.Success(newCityEntity.Id);
        return result.IsSuccess ? Result<Guid>.Success(newCityEntity.Id) : 
            Result<Guid>.Failure(new("SQL.Error", "Sql Error from App-Layer"));
    }
}
