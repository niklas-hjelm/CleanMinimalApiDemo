using CleanMinimalAPIDemo.Domain.Models;

namespace CleanMinimalAPIDemo.Domain.Services.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepositoryService<Pet> PetRepository { get; }
    IRepositoryService<Person> PeopleRepository { get; }
    Task SaveAsync();
}