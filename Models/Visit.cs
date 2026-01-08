namespace VisitCounter.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}