namespace ShelterBuddy.CodePuzzle.Core.Entities;

public interface IAuditStamper
{
    DateTimeOffset Now { get; }
    string Name { get; }
}