using Jacustran.SharedKernel.Abstractions.Events;
using Jacustran.SharedKernel.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jacustran.SharedKernel.Abstractions.Entities;

public abstract class EntityBase<TId> : AuditableEntity where TId : struct
{
    protected EntityBase() { }
    protected EntityBase(TId id) => Id = id;

    public TId Id { get; set; }

    [NotMapped]
    public List<DomainEventBase> DomainEvents { get; set; } = new();

    //public AuditProperties AuditProperties { get; set; } = AuditProperties.Default;

   

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is EntityBase<TId> other)) return false;

        if (ReferenceEquals(this, other))  return true;

        if (GetType() != other.GetType())  return false;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);

        
    }

    public static bool operator ==(EntityBase<TId>? a, EntityBase<TId>? b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;

        return a.Equals(b);
    }

    public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b) => !(a == b);

    public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
}

public abstract class AuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }

    //public bool IsDeleted { get; set; }
    //public DateTime? DeletedAt { get; set; }
    //public string DeletedBy { get; set; }
    //public string DeletedReason { get; set; }

}