using VisitCounter.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

static void SetupDatabase(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("VisitCounterDB");

builder.Services.AddDbContext<AppDbContext>(SetupDatabase);

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

app.Run();
