using ShelterBuddy.CodePuzzle.Core.Entities;
using Shouldly;
using Xunit;

namespace ShelterBuddy.CodePuzzle.Core.Tests.Entities;


public class AnimalTests
{
    [Fact]
    public void Animal_AgeTest_IsCorrect()
    {
        var animal = new Animal
        {
            AgeYears = 7,
            AgeWeeks = 3
        };
        
        animal.AgeText.ShouldBe("7 years 3 weeks");
    }
}