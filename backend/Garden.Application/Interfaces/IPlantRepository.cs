namespace Garden.Application.Interfaces;

public interface IPlantRepository
{
    Task<IEnumerable<Garden.Domain.Plant>> GetAllAsync(int page, int pageSize);
    Task AddAsync(Garden.Domain.Plant plant);
    Task SaveChangesAsync();
}