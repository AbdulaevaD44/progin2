using System.ComponentModel.DataAnnotations;

namespace Garden.Application.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Описание задачи обязательно")]
    [StringLength(200, MinimumLength = 2)]
    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}

public class CreateTaskDto
{
    [Required(ErrorMessage = "Описание задачи обязательно")]
    [StringLength(200, MinimumLength = 2)]
    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }
}