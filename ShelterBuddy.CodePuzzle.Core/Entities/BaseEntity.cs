namespace ShelterBuddy.CodePuzzle.Core.Entities;

public class BaseEntity<TKey> : IIdentifiable<TKey>, IAuditable, ISoftDeletable
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; private set; }
    public string? CreatedBy { get; private set; }
    public void Created(IAuditStamper stamper)
    {
        CreatedAt = stamper.Now;
        CreatedBy = stamper.Name;
    }

    public bool IsDeleted { get; set; }
}