using Applications.Implement;
using DesignPattern.Controllers.BehavioralPatterns.Mediator;
using DesignPattern.Controllers.BehavioralPatterns.Memento;
using DesignPattern.Controllers.BehavioralPatterns.Observer;
using DesignPattern.Controllers.BehavioralPatterns.State;
using DesignPattern.Controllers.BehavioralPatterns.Strategy;
using DesignPattern.Controllers.BehavioralPatterns.TemplateMethod;
using DesignPattern.Controllers.BehavioralPatterns.Vistor;
using DesignPattern.Controllers.StructuralPatterns;
using Infrastructures.Implement;
using Infrastructures.Models.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
InfrastructuresDI.Setup(builder.Services);
ApplicationsDI.Setup(builder.Services);
ProxyController.Setup(builder.Services);
MediatorController.Setup(builder.Services);
MementoController.Setup(builder.Services);
ObserverController.Setup(builder.Services);
StateController.Setup(builder.Services);
StrategyController.Setup(builder.Services);
TemplateMethodController.Setup(builder.Services);
VistorController.Setup(builder.Services);

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
