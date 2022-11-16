namespace ShelterBuddy.CodePuzzle.Core.Entities;

public interface IAuditable
{
    public DateTimeOffset CreatedAt { get; }
    public string? CreatedBy { get; }
    public void Created(IAuditStamper stamper);
}