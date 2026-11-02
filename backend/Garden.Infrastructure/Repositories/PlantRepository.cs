using Garden.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garden.Infrastructure.Repositories;

public class PlantRepository : IPlantRepository
{
    private readonly AppDbContext _context;
    
    public PlantRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Garden.Domain.Plant>> GetAllAsync(int page, int pageSize)
        => await _context.Plants.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

    public async Task AddAsync(Garden.Domain.Plant plant)
        => await _context.Plants.AddAsync(plant);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}