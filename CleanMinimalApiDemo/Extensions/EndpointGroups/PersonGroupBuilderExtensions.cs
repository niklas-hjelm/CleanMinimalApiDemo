using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Dtos;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;

namespace CleanMinimalApiDemo.API.Extensions.EndpointGroups;

public static class PersonGroupBuilderExtensions
{
    public static RouteGroupBuilder MapPersonGroup(this RouteGroupBuilder builder)
    {
        builder.MapGet("/all", GetAllPeopleHandler).WithOpenApi();
        builder.MapGet("/{id}", GetPersonHandler).WithOpenApi();
        builder.MapPost("/", SavePersonHandler).WithOpenApi();  
        builder.MapPut("/{id}", UpdatePersonHandler).WithOpenApi();
        return builder;
    }

    private static async Task<IResult> UpdatePersonHandler(IUnitOfWork unitOfWork, [AsParameters] UpdatePersonRequest request)
    {
        var personToUpdate = await unitOfWork.PeopleRepository.GetAsync(request.Id);
        if (personToUpdate is null)
        {
            return Results.NotFound($"No person with id {request.Id} found");
        }
        personToUpdate.FirstName = request.Person.FirstName;
        personToUpdate.LastName = request.Person.LastName;
        personToUpdate.Email = request.Person.Email;
        personToUpdate.Phone = request.Person.Phone;
        personToUpdate.Address = request.Person.Address;
        personToUpdate.City = request.Person.City;
        await unitOfWork.SaveAsync();
        return Results.Ok(personToUpdate);
    }

    private static async Task<IResult> SavePersonHandler(IUnitOfWork unitOfWork, PersonDto person)
    {
        var personToSave = new Person
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            City = person.City
        };
        await unitOfWork.PeopleRepository.AddAsync(personToSave);
        await unitOfWork.SaveAsync();
        return Results.Ok(personToSave);
    }

    private static async Task<IResult> GetPersonHandler(IUnitOfWork unitOfWork, int id)
    {
        var person = await unitOfWork.PeopleRepository.GetAsync(id);
        var result = new PersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            City = person.City
        };
        return Results.Ok(result);
    }

    private static async Task<IResult> GetAllPeopleHandler(IUnitOfWork unitOfWork)
    {
        var allPeople = await unitOfWork.PeopleRepository.GetAllAsync();
        var result = allPeople.Select(p => new PersonDto
        {
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            Address = p.Address,
            City = p.City
        });
        return Results.Ok(result);
    }
}