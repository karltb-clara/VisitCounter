using VisitCounter.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

static async Task<string> Page(AppDbContext db)
{
    var visit = new Visit();
    db.Visits.Add(visit);
    await db.SaveChangesAsync();

    var count = await db.Visits.CountAsync();
    return $"This page has been visited {count} times.";
}

app.MapGet("/", Page);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var user = await db.Database.ExecuteSqlRawAsync("SELECT SYSTEM_USER;");
    Console.WriteLine($"=== Connected to database as: {user} ===");
    await db.Database.MigrateAsync();
}

app.Run();
