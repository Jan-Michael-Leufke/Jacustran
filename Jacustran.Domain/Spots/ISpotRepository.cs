using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Domain.Spots;

public interface ISpotRepository : IAsyncRepository<Spot, Guid>
{
    Task<bool> IsCityIdValid(Guid cityId, CancellationToken token);
    Task<Spot?> GetSpotWithTown(Guid spotId, CancellationToken token);
    Task<IEnumerable<Spot>> GetSpotsForCity(Guid cityId, CancellationToken token);
}
