using CleanMinimalAPIDemo.Domain.Dtos;

namespace CleanMinimalApiDemo.API.Endpoints.Requests;

public class UpdatePersonRequest :IHttpRequest
{
    public PersonDto Person { get; set; }
    public int Id { get; set; }
}