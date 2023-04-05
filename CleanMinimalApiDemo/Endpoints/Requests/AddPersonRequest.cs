using CleanMinimalAPIDemo.Domain.Dtos;

namespace CleanMinimalApiDemo.API.Endpoints.Requests;

public class AddPersonRequest : IHttpRequest
{
    public PersonDto Person { get; set; }
}