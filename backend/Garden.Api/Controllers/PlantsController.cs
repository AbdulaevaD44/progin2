using Garden.Application.Dtos;
using Garden.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    private readonly IPlantRepository _repository;

    public PlantsController(IPlantRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantDto>>> GetPlants(int page = 1, int pageSize = 10)
    {
        var plants = await _repository.GetAllAsync(page, pageSize);
        
        var dtos = plants.Select(p => new PlantDto
        {
            Id = p.Id,
            Name = p.Name,
            Location = p.Location,
            PlantingDate = p.PlantingDate,
            NeedsWatering = p.NeedsWatering
        });

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult<PlantDto>> CreatePlant(CreatePlantDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var plant = new Garden.Domain.Plant
        {
            Name = dto.Name,
            Location = dto.Location,
            PlantingDate = dto.PlantingDate,
            NeedsWatering = false
        };

        await _repository.AddAsync(plant);
        await _repository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlants), new { id = plant.Id }, plant);
    }
}