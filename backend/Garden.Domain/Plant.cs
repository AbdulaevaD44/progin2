namespace Garden.Domain;

public class Plant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime PlantingDate { get; set; }
    public bool NeedsWatering { get; set; }
}