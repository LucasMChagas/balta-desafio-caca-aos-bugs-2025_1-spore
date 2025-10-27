var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;

app.MapGet("/", () => "Hello World!");

app.Run();
