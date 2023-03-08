using FluentValidation;
using Management.API.Dtos;
using Management.Domain.Models;
using Management.Infraestructure.ServiceExtension;
using Management.Services;
using Management.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
//builder.Services.AddScoped<IPersonService, PersonService>();
//builder.Services.AddScoped<IClientService, ClientService>();


builder.Services.AddScoped<IValidator<PersonDto>, PersonValidator>();

builder.Services.AddScoped<IValidator<ClientDto>, ClientValidator>();
builder.Services.AddScoped<IValidator<ClientUpdatedDto>, ClientUpdatedValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
