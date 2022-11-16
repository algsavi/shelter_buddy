using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public interface IRepository<T, TKey>
    where T : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public T? GetEntity(TKey id);
    public IQueryable<T> GetAll();
    public void Delete(T entity);
    public void Add(T entity);
}