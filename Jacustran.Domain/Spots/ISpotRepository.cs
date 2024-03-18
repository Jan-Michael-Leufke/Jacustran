namespace Jacustran.Domain.Spots;

public interface ISpotRepository : IAsyncRepository<Spot>
{
    Task<bool> IsCityIdValid(Guid cityId, CancellationToken token);
    Task<Spot?> GetSpotWithTown(Guid spotId, CancellationToken token);
}
