using CleanMinimalAPIDemo.Domain.Dtos;

namespace CleanMinimalApiDemo.API.Endpoints.Requests;

public class UpdatePersonRequest
{
    public PersonDto Person { get; set; }
    public int Id { get; set; }
}