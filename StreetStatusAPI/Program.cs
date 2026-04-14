using Microsoft.EntityFrameworkCore;
using StreetStatusAPI.Database;
using StreetStatusAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Registra los DbContext con SQLite
builder.Services.AddDbContext<StreetDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra los servicios
builder.Services.AddScoped<IStreetService, StreetService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
