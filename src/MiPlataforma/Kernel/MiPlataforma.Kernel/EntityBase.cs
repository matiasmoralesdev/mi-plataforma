namespace MiPlataforma.Kernel;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = string.Empty;

    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }

    public virtual void UpdateAuditData(string username)
    {
        LastModifiedBy = username;
        LastModifiedDate = DateTime.UtcNow;
    }

    public virtual void Delete(string username)
    {
        DeletedBy = username;
        DeletedDate = DateTime.UtcNow;
        UpdateAuditData(username);
    }
}
