using System.Reflection;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public class BaseRepository<T, TKey> : IRepository<T, TKey>
    where T : BaseEntity<TKey>, IAuditable
    where TKey : IEquatable<TKey>
{
    private ICollection<T> data = new List<T>();
    private IAuditStamper auditStamper = new AuditStamper();
    
    protected BaseRepository()
    {
    }

    protected void Load(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var streamReader = new StreamReader(stream))
        {
            var animalsData = streamReader.ReadToEnd();
            var animals = JsonConvert.DeserializeObject<T[]>(animalsData);

            data.Clear();
            foreach (var item in animals)
            {
                data.Add(item);
            }
        }
    }

    public T? GetEntity(TKey id) =>
        data.FirstOrDefault(entity => entity.Id.Equals(id));

    public IQueryable<T> GetAll() => data.AsQueryable();

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
    }

    public void Add(T entity)
    {
        entity.Created(auditStamper);
        
        data.Add(entity);
    }

    private class AuditStamper : IAuditStamper
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public string Name => "Test";
    }
}