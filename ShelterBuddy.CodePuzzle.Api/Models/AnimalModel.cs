using System.ComponentModel.DataAnnotations;

namespace ShelterBuddy.CodePuzzle.Api.Models;

public class AnimalModel
{
    public string? Id { get; init; }
    [Required(ErrorMessage ="Name is required.")]
    public string? Name { get; init; }
    public string? Colour { get; init; }
    public string? MicrochipNumber { get; init; }
    [Required(ErrorMessage = "Date of Birth is required.")]
    public DateTime? DateOfBirth { get; init; }
    public DateTime? DateInShelter { get; init; }
    public DateTime? DateLost { get; init; }
    public DateTime? DateFound { get; init; }
    [Required(ErrorMessage = "Age in Years is required.")]
    public int? AgeYears { get; init; }
    [Required(ErrorMessage = "Age in Months is required.")]
    public int? AgeMonths { get; init; }
    [Required(ErrorMessage = "Age in Weekds is required.")]
    public int? AgeWeeks { get; init; }
    public string? AgeText { get; init; }

    [Required]
    public string? Specie { get; init; }
}