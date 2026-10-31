using Garden.Domain;
using Microsoft.EntityFrameworkCore;

namespace Garden.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Plant> Plants { get; set; }
    public DbSet<Garden.Domain.Task> Tasks { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Заглушка данных с фиксированными ID
        modelBuilder.Entity<Plant>().HasData(
            new Plant { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                Name = "🍅 Помидоры", 
                Location = "Теплица", 
                PlantingDate = new DateTime(2026, 5, 1), 
                NeedsWatering = true 
            },
            new Plant { 
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                Name = "🥒 Огурцы", 
                Location = "Грядка №3", 
                PlantingDate = new DateTime(2026, 5, 10), 
                NeedsWatering = false 
            }
        );
    }
}