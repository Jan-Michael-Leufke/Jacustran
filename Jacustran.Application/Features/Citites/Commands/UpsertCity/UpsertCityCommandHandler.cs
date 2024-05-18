
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Application.Features.Citites.Commands.UpdateCity;

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


    public async Task<Result<(Guid, bool)>> Handle(UpsertCityCommand request, CancellationToken cancellationToken)
    {
        var city = request.Spots is null || !request.Spots.Any() ?
            await _cityRepository.GetByIdAsync(request.CityId, cancellationToken) : 
            await _cityRepository.GetCityWithSpots(request.CityId, cancellationToken);

        if (city == null) 
        {
            city = _mapper.Map<City>(request);
            city.Id = request.CityId; 
            _cityRepository.Add(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<(Guid, bool)>.Success((city.Id, true));
        }

       _mapper.Map(request, city);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
