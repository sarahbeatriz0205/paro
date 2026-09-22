using Microsoft.EntityFrameworkCore;
using Paro.Models;
using Paro.Repositories;
using Paro.Repositories.RepositoryInterfaces;
using Paro.Services;
using Paro.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositório
builder.Services.AddScoped<IRepository<Jogador>, JogadorRepository>();

// Service
builder.Services.AddScoped<JogadorService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // configuração pra eu poder documentar com swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Paro API");
        options.RoutePrefix = "swagger";
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();