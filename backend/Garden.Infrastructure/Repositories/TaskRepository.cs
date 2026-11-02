using Dapper;
using Garden.Application.Interfaces;
using Npgsql;

namespace Garden.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly string _connectionString;

    public TaskRepository(string connectionString) => _connectionString = connectionString;

    public async Task<IEnumerable<Garden.Domain.Task>> GetAllAsync(int page, int pageSize)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "SELECT * FROM \"Tasks\" ORDER BY \"DueDate\" LIMIT @PageSize OFFSET @Offset";
        return await connection.QueryAsync<Garden.Domain.Task>(sql, new { PageSize = pageSize, Offset = (page - 1) * pageSize });
    }

    public async Task AddAsync(Garden.Domain.Task task)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "INSERT INTO \"Tasks\" (\"Id\", \"Description\", \"DueDate\", \"IsCompleted\", \"PlantId\") VALUES (@Id, @Description, @DueDate, @IsCompleted, @PlantId)";
        await connection.ExecuteAsync(sql, task);
    }
}