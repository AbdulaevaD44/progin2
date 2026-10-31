using System.ComponentModel.DataAnnotations;

namespace Garden.Application.Dtos;

public class PlantDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Название обязательно")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Место посадки обязательно")]
    public string Location { get; set; } = string.Empty;

    public DateTime PlantingDate { get; set; }
    public bool NeedsWatering { get; set; }
}

public class CreatePlantDto
{
    [Required(ErrorMessage = "Название обязательно")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    public DateTime PlantingDate { get; set; }
}