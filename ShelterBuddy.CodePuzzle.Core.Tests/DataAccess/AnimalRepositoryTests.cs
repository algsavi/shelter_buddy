using ShelterBuddy.CodePuzzle.Core.DataAccess;
using Shouldly;
using Xunit;

namespace ShelterBuddy.CodePuzzle.Core.Tests.DataAccess;

public class AnimalRepositoryTests
{
    [Fact]
    public void New_CanLoadData()
    {
        var repository = new AnimalRepository();

        var animals = repository.GetAll();

        animals.ShouldNotBeEmpty();
    }
}