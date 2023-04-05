using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using CleanMinimalApiDemo.Service.Services;
using MediatR;

namespace CleanMinimalApiDemo.API.Endpoints.Handlers;

public class AddPersonHandler : IRequestHandler<AddPersonRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPersonHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var personToUpdate = await _unitOfWork.PeopleRepository.GetAsync(request.Id);
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
        await _unitOfWork.SaveAsync();
        return Results.Ok(personToUpdate);
    }
}