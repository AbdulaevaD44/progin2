using Garden.Application.Dtos;
using Garden.Domain;
using Garden.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garden.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlantsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantDto>>> GetPlants(int page = 1, int pageSize = 10)
    {
        var plants = await _context.Plants
            .Skip((page - 1) * pageSize) 
            .Take(pageSize)             
            .Select(p => new PlantDto
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                PlantingDate = p.PlantingDate,
                NeedsWatering = p.NeedsWatering
            })
            .ToListAsync();

        return Ok(plants); // HTTP 200
    }

    [HttpPost]
    public async Task<ActionResult<PlantDto>> CreatePlant(CreatePlantDto dto)
    {
        // если не пройдена, вернет 400
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var plant = new Plant
        {
            Name = dto.Name,
            Location = dto.Location,
            PlantingDate = dto.PlantingDate,
            NeedsWatering = false
        };

        _context.Plants.Add(plant);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlants), new { id = plant.Id }, plant); // HTTP 201 Created
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlant(Guid id)
    {
        var plant = await _context.Plants.FindAsync(id);
        if (plant == null) return NotFound(); // HTTP 404

        _context.Plants.Remove(plant);
        await _context.SaveChangesAsync();

        return NoContent(); // HTTP 204
    }
}