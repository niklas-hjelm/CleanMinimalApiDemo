using CleanMinimalApiDemo.DataAccess.Contexts;
using CleanMinimalAPIDemo.Domain.Models;
using CleanMinimalAPIDemo.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanMinimalApiDemo.Service.Services;

public class PetRepositoryService : IRepositoryService<Pet>
{
    private readonly PetInfoContext _context;
    public PetRepositoryService(PetInfoContext context)
    {
        _context = context;
    }
    public async Task<Pet?> GetAsync(int id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets.ToListAsync();
    }

    public async Task<Pet> AddAsync(Pet entity)
    {
        await _context.Pets.AddAsync(entity);
        return entity;
    }

    public Pet UpdateAsync(Pet entity)
    {
        _context.Update(entity);
        return entity;
    }

    public Pet DeleteAsync(Pet entity)
    {
        _context.Pets.Remove(entity);
        return entity;
    }
}