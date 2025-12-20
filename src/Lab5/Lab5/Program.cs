using Lab5.Application;
using Lab5.Infrastructure;
using Lab5.Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? password = builder.Configuration["AdminSettings:Password"];
ArgumentNullException.ThrowIfNull(password);

builder.Services
    .AddApplication()
    .AddInfrastructure(password)
    .AddPresentation();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();