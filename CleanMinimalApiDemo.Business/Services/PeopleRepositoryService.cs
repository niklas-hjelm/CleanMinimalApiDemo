using CleanMinimalApiDemo.DataAccess.Contexts;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanMinimalApiDemo.Service.Services;

public class PeopleRepositoryService : IRepositoryService<Person>
{
    private readonly PetInfoContext _context;

    public PeopleRepositoryService(PetInfoContext context)
    {
        _context = context;
    }
    public async Task<Person?> GetAsync(int id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<Person> AddAsync(Person entity)
    {
        await _context.People.AddAsync(entity);
        return entity;
    }

    public Person UpdateAsync(Person entity)
    {
        _context.Update(entity);
        return entity;
    }

    public Person DeleteAsync(Person entity)
    {
        _context.People.Remove(entity);
        return entity;
    }
}