namespace ShelterBuddy.CodePuzzle.Core.Entities;

public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
}