using CleanMinimalApiDemo.DataAccess.Contexts;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;

namespace CleanMinimalApiDemo.Service.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly PetInfoContext _context;
    public IRepositoryService<Pet> PetRepository { get; }
    public IRepositoryService<Person> PeopleRepository { get; }

    public UnitOfWork(PetInfoContext context)
    {
        _context = context;
        PetRepository = new PetRepositoryService(_context);
        PeopleRepository = new PeopleRepositoryService(_context);
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}