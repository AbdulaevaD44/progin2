using Garden.Application.Dtos;
using Garden.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks(int page = 1, int pageSize = 10)
    {
        var tasks = await _repository.GetAllAsync(page, pageSize);
        
        var dtos = tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Description = t.Description,
            DueDate = t.DueDate,
            IsCompleted = t.IsCompleted
        });

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var task = new Garden.Domain.Task
        {
            Description = dto.Description,
            DueDate = dto.DueDate,
            IsCompleted = false
        };

        await _repository.AddAsync(task);
        return Ok();
    }
}