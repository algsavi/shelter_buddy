using System.Reflection;
using Newtonsoft.Json;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public class BaseRepository<T, TKey> : IRepository<T, TKey>
    where T : BaseEntity<TKey>, IAuditable
    where TKey : IEquatable<TKey>
{
    private ICollection<T> data = new List<T>();
    private IAuditStamper auditStamper = new AuditStamper();

    private string _resourceName;

    protected BaseRepository()
    {
    }

    protected void Load(string resourceName)
    {
        _resourceName = resourceName;

        var assembly = Assembly.GetExecutingAssembly();

        using (var stream = assembly.GetManifestResourceStream(_resourceName))
        using (var streamReader = new StreamReader(stream))
        {
            var animalsData = streamReader.ReadToEnd();
            var animals = JsonConvert.DeserializeObject<T[]>(animalsData);

            data.Clear();

            if (!(animals is null))
            {
                foreach (var item in animals)
                {
                    data.Add(item);
                }
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

        var animals = JsonConvert.SerializeObject(data, Formatting.Indented);

        using (var streamWriter = new StreamWriter(@"..\ShelterBuddy.CodePuzzle.Core\DataAccess\Data\Animals.json"))
        {
            streamWriter.WriteLine(animals);
        }
    }

}