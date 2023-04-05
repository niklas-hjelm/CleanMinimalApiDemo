using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using CleanMinimalApiDemo.Service.Services;
using MediatR;

namespace CleanMinimalApiDemo.API.Endpoints.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonHandler(IUnitOfWork unitOfWork)s
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
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
}