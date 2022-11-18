using Microsoft.AspNetCore.Mvc;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;
using System.Linq;

namespace ShelterBuddy.CodePuzzle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IRepository<Animal, Guid> repository;

    public AnimalController(IRepository<Animal, Guid> animalRepository)
    {
        repository = animalRepository;
    }

    [HttpGet]
    public AnimalModel[] Get() => repository.GetAll().Select(animal => new AnimalModel
    {
        Id = $"{animal.Id}",
        Name = animal.Name,
        Colour = animal.Colour,
        DateFound = animal.DateFound,
        DateLost = animal.DateLost,
        MicrochipNumber = animal.MicrochipNumber,
        DateInShelter = animal.DateInShelter,
        DateOfBirth = animal.DateOfBirth,
        AgeText = animal.AgeText,
        AgeMonths = animal.AgeMonths,
        AgeWeeks = animal.AgeWeeks,
        AgeYears = animal.AgeYears,
        Specie = animal.Specie
    }).ToArray();

    [HttpPost]
    public void Post(AnimalModel newAnimal)
    {
        Animal animal = new Animal
        {
            Id = Guid.NewGuid(),
            Name = newAnimal.Name,
            Colour = newAnimal.Colour,
            DateFound = newAnimal.DateFound,
            DateLost = newAnimal.DateLost,
            MicrochipNumber = newAnimal.MicrochipNumber,
            DateInShelter = newAnimal.DateInShelter,
            DateOfBirth = newAnimal.DateOfBirth,
            AgeMonths = newAnimal.AgeMonths,
            AgeWeeks = newAnimal.AgeWeeks,
            AgeYears = newAnimal.AgeYears,
            Specie = newAnimal.Specie
        };

        repository.Add(animal);
    }
}