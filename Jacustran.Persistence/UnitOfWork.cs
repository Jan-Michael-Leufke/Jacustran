using Jacustran.Domain.Entity.Shared;
using Jacustran.Domain.Responses;

namespace Jacustran.Persistence;

public class UnitOfWork(JacustranDbContext jacustranDbContext) : IUnitOfWork
{
    private readonly JacustranDbContext _context = jacustranDbContext;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditProperties();

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Result<int>> TrySaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditProperties();

        try
        {
            return Result<int>.Success(await _context.SaveChangesAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(new("Sql.Error", "Exception thrown during saving changes"));
        }
    }


    private void SetAuditProperties()
    {
        foreach (var entry in _context.ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "Jacustran";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "Jacustran";
                    break;
            }

            //switch (entry.State)
            //{
            //    case EntityState.Added:
            //        entry.CurrentValues[nameof(EntityBase.CreatedDate)] = DateTime.Now;
            //        entry.CurrentValues[nameof(EntityBase.CreatedBy)] = "Jacustran";
            //        break;
            //    case EntityState.Modified:
            //        entry.CurrentValues[nameof(EntityBase.LastModifiedDate)] = DateTime.Now;
            //        entry.CurrentValues[nameof(EntityBase.LastModifiedBy)] = "Jacustran";
            //        break;
            //}

        }
    }

   
}
