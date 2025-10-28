using BugStore.Data;
using BugStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/customer", (AppDbContext context, Customer customer) =>
{
    customer.Id = Guid.NewGuid();
    customer.BirthDate = new DateTime(1993,06,11);
    context.Customers.Add(customer);
    context.SaveChanges();
});

app.Run();
