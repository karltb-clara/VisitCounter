using Microsoft.EntityFrameworkCore;

namespace VisitCounter.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Visit> Visits { get; set; }
}