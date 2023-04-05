using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using CleanMinimalApiDemo.Service.Services;
using MediatR;
using CleanMinimalAPIDemo.Domain.Models;

namespace CleanMinimalApiDemo.API.Endpoints.Handlers;

public class AddPersonHandler : IRequestHandler<AddPersonRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPersonHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddPersonRequest request, CancellationToken cancellationToken)
    {
        var personToSave = new Person
        {
            FirstName = request.Person.FirstName,
            LastName = request.Person.LastName,
            Pets = request.Person.PetIds.Select(petId => new Pet { Id = petId }).ToList(),
            Email = request.Person.Email,
            Phone = request.Person.Phone,
            Address = request.Person.Address,
            City = request.Person.City
        };
        await _unitOfWork.PeopleRepository.AddAsync(personToSave);
        await _unitOfWork.SaveAsync();
        return Results.Ok(personToSave);
    }
}