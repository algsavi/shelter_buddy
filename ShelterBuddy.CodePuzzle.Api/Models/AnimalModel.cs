namespace ShelterBuddy.CodePuzzle.Api.Models;

public class AnimalModel
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? Colour { get; init; }
    public string? MicrochipNumber { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public DateTime? DateInShelter { get; init; }
    public DateTime? DateLost { get; init; }
    public DateTime? DateFound { get; init; }
    public int? AgeYears { get; init; }
    public int? AgeMonths { get; init; }
    public int? AgeWeeks { get; init; }
    public string? AgeText { get; init; }
}