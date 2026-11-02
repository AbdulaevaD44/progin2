namespace Garden.Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Garden.Domain.Task>> GetAllAsync(int page, int pageSize);
    Task AddAsync(Garden.Domain.Task task);
}