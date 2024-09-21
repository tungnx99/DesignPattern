using Applications.Implement;
using Infrastructures.Implement;
using Infrastructures.Models.Configs;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
InfrastructuresDI.Setup(builder.Services);
ApplicationsDI.Setup(builder.Services);

var configs = builder.Configuration.GetSection("Configs");
//builder.Services.Configure<CloudConfig>(configs);
builder.Services.AddSingleton<CloudConfig>(configs.Get<CloudConfig>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
