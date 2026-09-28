using Microsoft.EntityFrameworkCore;
using Paro;
using Paro.HateoasBuilders;
using Paro.Services;
using Paro.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<ContextDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service
builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<JogadorService>();
builder.Services.AddScoped<RodadaService>();
builder.Services.AddScoped<RespostaService>();

builder.Services.AddSingleton<Factory>();

builder.Services.AddHttpContextAccessor(); 
builder.Services.AddScoped<SalaHateoasBuilder>();

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