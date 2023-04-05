using CleanMinimalApiDemo.API.Endpoints.Handlers;
using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalAPIDemo.Domain.Dtos;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using CleanMinimalApiDemo.Service.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanMinimalApiDemo.API.Tests;

public class PersonEndpointTests
{
    [Fact]
    public async Task GetAllPeopleHandler_Returns_ListOfPeople()
    {
        //Arrange
        var count = 10;
        var dummyPeople = A.CollectionOfDummy<Person>(count) as IEnumerable<Person>;

        var dummyRequest = A.Dummy<GetAllPeopleRequest>();

        var unitOfWork = A.Fake<IUnitOfWork>();

        A.CallTo(() => unitOfWork.PeopleRepository.GetAllAsync()).Returns(Task.FromResult(dummyPeople));

        var sut = new GetAllPeopleHandler(unitOfWork);

        //Act

        var result = await sut.Handle(dummyRequest, CancellationToken.None);

        //Assert

        Assert.IsType<Ok<IEnumerable<PersonDto>>>(result);
        Assert.Equal(count, (result as Ok<IEnumerable<PersonDto>>).Value.Count());
    }
}