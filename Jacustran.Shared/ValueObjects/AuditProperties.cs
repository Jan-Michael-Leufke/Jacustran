using Jacustran.SharedKernel.Abstractions.ValueObject;

namespace Jacustran.SharedKernel.ValueObjects;

public sealed class AuditProperties : ValueObject<AuditProperties>
{
    public string? CreatedBy { get; }
    public DateTime CreatedDate { get; }
    public string? LastModifiedBy { get; }
    public DateTime LastModifiedDate { get; }

    //public bool IsDeleted { get; }
    //public DateTime? DeletedAt { get; }
    //public string DeletedBy { get; }
    //public string DeletedReason { get; }

    private AuditProperties() { }

    public static readonly AuditProperties Default = new AuditProperties();

    public AuditProperties(string? createdBy, DateTime createdDate)
    {
        CreatedBy = createdBy;
        CreatedDate = createdDate;
    }

    public AuditProperties(string? createdBy, DateTime createdDate, string? lastModifiedBy, DateTime lastModifiedDate)
    {
        CreatedBy = createdBy;
        CreatedDate = createdDate;
        LastModifiedBy = lastModifiedBy;
        LastModifiedDate = lastModifiedDate;
    }


    protected override bool EqualsCore(AuditProperties other)
    {
        throw new NotImplementedException();
    }

    protected override int GetHashCodeCore()
    {
        throw new NotImplementedException();
    }
}
