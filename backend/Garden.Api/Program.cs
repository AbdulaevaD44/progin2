using Garden.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Garden.Domain; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("GardenDb"));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// --- ПРИНУДИТЕЛЬНОЕ ЗАПОЛНЕНИЕ БАЗЫ ПРИ СТАРТЕ ---
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Plants.Any())
    {
        context.Plants.Add(new Plant { Name = "🍅 Помидоры", Location = "Теплица", PlantingDate = new DateTime(2026, 5, 1), NeedsWatering = true });
        context.Plants.Add(new Plant { Name = "🥒 Огурцы", Location = "Грядка №3", PlantingDate = new DateTime(2026, 5, 10), NeedsWatering = false });
        context.Plants.Add(new Plant { Name = "🍓 Клубника", Location = "Грядка №1", PlantingDate = new DateTime(2026, 4, 15), NeedsWatering = false });
        context.SaveChanges();
    }
}
// ------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();