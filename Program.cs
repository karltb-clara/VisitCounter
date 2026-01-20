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
    await db.Database.MigrateAsync();
}

app.Run();
