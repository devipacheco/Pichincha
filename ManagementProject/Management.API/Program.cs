using FluentValidation;
using Management.API.Dtos;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Movement;
using Management.Domain.Models;
using Management.Infraestructure.ServiceExtension;
using static Management.Domain.Dtos.Account.AccountDto;
using static Management.Domain.Dtos.Account.AccountUpdatedDto;
using static Management.Domain.Dtos.Movement.MovementDto;
using static Management.Domain.Dtos.Movement.MovementUpdatedDto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
//builder.Services.AddScoped<IPersonService, PersonService>();
//builder.Services.AddScoped<IClientService, ClientService>();


builder.Services.AddScoped<IValidator<PersonDto>, PersonValidator>();

builder.Services.AddScoped<IValidator<ClientDto>, ClientValidator>();
builder.Services.AddScoped<IValidator<ClientUpdatedDto>, ClientUpdatedValidator>();

builder.Services.AddScoped<IValidator<AccountDto>, AccountValidator>();
builder.Services.AddScoped<IValidator<AccountUpdatedDto>, AccountUpdatedValidator>();

builder.Services.AddScoped<IValidator<MovementDto>, MovementValidator>();
builder.Services.AddScoped<IValidator<MovementUpdatedDto>, MovementUpdatedValidator>();

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
