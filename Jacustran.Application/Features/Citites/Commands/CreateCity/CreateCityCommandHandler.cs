using Jacustran.Application.Contracts.Abstractions.MediatR;

namespace Jacustran.Application.Features.Citites.Commands.CreateCity;

public class CreateCityCommandHandler : ICommandHandler<CreateCityCommand, Guid>
{
    private readonly IAsyncRepository<City> _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityCommandHandler(IAsyncRepository<City> cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var newCityEntity = _mapper.Map<City>(request);

        _cityRepository.Add(newCityEntity);
        await _cityRepository.SaveChangesAsync(cancellationToken);

        //await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(newCityEntity.Id);
    }
}
