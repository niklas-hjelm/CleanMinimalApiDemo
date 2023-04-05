using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Dtos;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalApiDemo.Service.Services;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using MediatR;

namespace CleanMinimalApiDemo.API.Endpoints.Handlers;

public class GetAllPeopleHandler : IRequestHandler<GetAllPeopleRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllPeopleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(GetAllPeopleRequest request, CancellationToken cancellationToken)
    {
        var allPeople = await _unitOfWork.PeopleRepository.GetAllAsync();

        var result = allPeople.Select(p => new PersonDto
        {
            FirstName = p.FirstName,
            LastName = p.LastName,
            PetIds = p.Pets.Select(pet => pet.Id).ToList(),
            Email = p.Email,
            Phone = p.Phone,
            Address = p.Address,
            City = p.City
        });
        return Results.Ok(result);
    }
}