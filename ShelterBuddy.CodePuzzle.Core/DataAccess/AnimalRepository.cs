using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public class AnimalRepository : BaseRepository<Animal, Guid>
{
    public AnimalRepository()
    {
        Load("ShelterBuddy.CodePuzzle.Core.DataAccess.Data.Animals.json");
    }
}