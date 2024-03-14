namespace Jacustran.Domain.Shared;

public abstract class EntityBase
{
    protected EntityBase() { }
    protected EntityBase(Guid id) => Id = id;


    public Guid Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }

    //public bool IsDeleted { get; set; }
    //public DateTime? DeletedAt { get; set; }
    //public string DeletedBy { get; set; }
    //public string DeletedReason { get; set; }
}

