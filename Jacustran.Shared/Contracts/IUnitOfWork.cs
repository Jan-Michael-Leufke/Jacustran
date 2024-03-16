namespace Jacustran.Shared.Contracts;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task<Result<int>> TrySaveChangesAsync(CancellationToken cancellationToken = default);
}
