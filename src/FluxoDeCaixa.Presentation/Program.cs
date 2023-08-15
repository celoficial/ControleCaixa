#pragma warning disable S125 // Sections of code should not be commented out
using FluxoDeCaixa.Application;
using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Infrastructure;
using FluxoDeCaixa.Presentation;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddMetricServer(options => options.Url = "http://localhost:9090");

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();
builder.Services.AddAplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler("/error");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMetricServer();
app.UseHttpMetrics();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<IFluxoDeCaixaDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
#pragma warning restore S125 // Sections of code should not be commented out
