using Garden.Domain;
using Microsoft.EntityFrameworkCore;

namespace Garden.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Plant> Plants { get; set; }
    public DbSet<Garden.Domain.Task> Tasks { get; set; }
}