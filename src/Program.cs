using BugStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

app.MapGet("/", () => "Hello World!");

app.Run();
