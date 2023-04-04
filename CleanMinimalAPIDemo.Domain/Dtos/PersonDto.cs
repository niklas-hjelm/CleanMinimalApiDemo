namespace CleanMinimalAPIDemo.Domain.Dtos;

public class PersonDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public List<int> PetIds { get; set; } = new ();
}