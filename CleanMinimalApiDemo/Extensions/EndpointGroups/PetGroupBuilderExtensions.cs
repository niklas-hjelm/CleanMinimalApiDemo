using CleanMinimalAPIDemo.Domain.Dtos;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;

namespace CleanMinimalApiDemo.API.Extensions.EndpointGroups;

public static class PetGroupBuilderExtensions
{
    public static RouteGroupBuilder MapPetGroup(this RouteGroupBuilder builder)
    {
        builder.MapGet("/all", GetAllPetsHandler).WithOpenApi();
        builder.MapGet("/{id}", GetPetHandler).WithOpenApi();
        builder.MapPost("/", SavePetHandler).WithOpenApi();
        builder.MapPut("/{id}", UpdatePetHandler).WithOpenApi();

        return builder;
    }

    private static async Task<IResult> UpdatePetHandler(IUnitOfWork unitOfWork, PetDto pet, int id)
    {
        var petToUpdate = await unitOfWork.PetRepository.GetAsync(id);
        if (petToUpdate is null)
        {
            return Results.NotFound($"No pet with id {id} found");
        }
        petToUpdate.Name = pet.Name;
        petToUpdate.Type = pet.Type;
        petToUpdate.Breed = pet.Breed;
        petToUpdate.Color = pet.Color;
        var owner = await unitOfWork.PeopleRepository.GetAsync(pet.OwnerId);
        if(owner is not null) petToUpdate.Owner = owner;
        await unitOfWork.SaveAsync();
        return Results.Ok(petToUpdate);
    }

    private static async Task<IResult> SavePetHandler(IUnitOfWork unitOfWork, PetDto pet)
    {
        var petToSave = new Pet
        {
            Name = pet.Name,
            Type = pet.Type,
            Breed = pet.Breed,
            Color = pet.Color
        };

        var owner = await unitOfWork.PeopleRepository.GetAsync(pet.OwnerId);
        if(owner is not null) petToSave.Owner = owner;
        await unitOfWork.PetRepository.AddAsync(petToSave);
        await unitOfWork.SaveAsync();
        return Results.Ok(petToSave);
    }

    private static async Task<IResult> GetAllPetsHandler(IUnitOfWork unitOfWork)
    {
        var allPets = await unitOfWork.PetRepository.GetAllAsync();
        var result = allPets.Select(p => new PetDto
        {
            Name = p.Name,
            Type = p.Type,
            OwnerId = p.Owner.Id,
            Breed = p.Breed,
            Color = p.Color
        });
        return Results.Ok(result);
    }
    private static async Task<IResult> GetPetHandler(IUnitOfWork unitOfWork, int id)
    {
        var pet = await unitOfWork.PetRepository.GetAsync(id);
        var result = new PetDto
        {
            Name = pet.Name,
            Type = pet.Type,
            OwnerId = pet.Owner.Id,
            Breed = pet.Breed,
            Color = pet.Color
        };
        return Results.Ok(result);
    }
}