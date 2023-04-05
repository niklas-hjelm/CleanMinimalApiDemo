using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Dtos;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;

namespace CleanMinimalApiDemo.API.Extensions.EndpointGroups;

public static class PersonGroupBuilderExtensions
{
    public static RouteGroupBuilder MapPersonGroup(this RouteGroupBuilder builder)
    {
        builder.MapGet("/{id}", GetPersonHandler).WithOpenApi();
        return builder;
    }

    private static async Task<IResult> GetPersonHandler(IUnitOfWork unitOfWork, int id)
    {
        var person = await unitOfWork.PeopleRepository.GetAsync(id);
        var result = new PersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            PetIds = person.Pets.Select(pet => pet.Id).ToList(),
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            City = person.City
        };
        return Results.Ok(result);
    }
}