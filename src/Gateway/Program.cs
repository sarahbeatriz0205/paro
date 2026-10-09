using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot configuration file
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFront", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();     
builder.Services.AddSwaggerForOcelot(builder.Configuration); 
var app = builder.Build();

app.UseSwaggerForOcelotUI(options =>                          
{
    options.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseCors("PermitirFront"); 

// Use Ocelot middleware
await app.UseOcelot();

app.Run();
