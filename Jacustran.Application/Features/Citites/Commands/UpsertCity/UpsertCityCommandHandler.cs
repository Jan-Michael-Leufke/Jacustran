
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Commands.UpsertCity;

internal class UpsertCityCommandHandler : ICommandHandler<UpsertCityCommand, (Guid, bool)>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpsertCityCommandHandler(ICityRepository cityRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result<(Guid, bool)>> Handle(UpsertCityCommand command, CancellationToken cancellationToken)
    {
        City? city = null;

        if (command.CityId != default)
        {
            city = command.Spots is null || !command.Spots.Any() ?
                await _cityRepository.GetByIdAsync(command.CityId, cancellationToken) :
                await _cityRepository.GetCityWithSpots(command.CityId, cancellationToken);
        }

        if (city == null) 
        {
            city = _mapper.Map<City>(command);
            city.Id = command.CityId; 
            _cityRepository.Add(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<(Guid, bool)>.Success((city.Id, true));
        }

       _mapper.Map(command, city);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
