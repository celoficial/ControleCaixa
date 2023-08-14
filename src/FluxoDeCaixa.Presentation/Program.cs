#pragma warning disable S125 // Sections of code should not be commented out
using FluxoDeCaixa.Application;
using FluxoDeCaixa.Infrastructure;
using FluxoDeCaixa.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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

app.Run();
#pragma warning restore S125 // Sections of code should not be commented out
