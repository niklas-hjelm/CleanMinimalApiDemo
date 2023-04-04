using CleanMinimalAPIDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanMinimalApiDemo.DataAccess.Contexts;

public class PetInfoContext : DbContext
{
    public PetInfoContext(DbContextOptions<PetInfoContext> options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Pet> Pets { get; set; } = null!;
}