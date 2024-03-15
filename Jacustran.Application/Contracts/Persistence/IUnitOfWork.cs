using System.Reflection.Metadata.Ecma335;

namespace Jacustran.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public Task<Result<int>> TrySaveChangesAsync(CancellationToken cancellationToken = default);
}
