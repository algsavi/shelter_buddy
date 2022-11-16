namespace ShelterBuddy.CodePuzzle.Core.Entities;

public interface IIdentifiable<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}