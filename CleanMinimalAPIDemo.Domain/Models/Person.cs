using System.ComponentModel.DataAnnotations;

namespace CleanMinimalAPIDemo.Domain.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}