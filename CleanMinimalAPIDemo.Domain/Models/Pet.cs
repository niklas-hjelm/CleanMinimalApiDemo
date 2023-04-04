namespace CleanMinimalAPIDemo.Domain.Models;

public class Pet
{
    public int Id { get; set; }
    public Person Owner { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Type { get; set; }
    public string? Breed { get; set; }
    public string? Color { get; set; }
}