using Jacustran.SharedKernel.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Application.Features.Citites.Commands.CreateCities;

internal class CreateCitiesCommandHandler : ICommandHandler<CreateCitiesCommand, CreateCitiesResponse>
{
    private readonly IAsyncRepository<City, Guid> _cityRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCitiesCommandHandler(IAsyncRepository<City, Guid> cityRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateCitiesResponse>> Handle(CreateCitiesCommand request, CancellationToken cancellationToken)
    {
        var cities = _mapper.Map<IEnumerable<City>>(request.Cities);

        _cityRepository.AddRange(cities);    

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CreateCitiesResponse>.Success(new() { CityIds = cities.Select(c => c.Id) });
    }
}
