namespace CleanMinimalAPIDemo.Domain.Dtos;

public class PetDto
{
    public int OwnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Type { get; set; }
    public string? Breed { get; set; }
    public string? Color { get; set; }
}