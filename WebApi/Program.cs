using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped(typeof(IBaseService<Customer, CustomerEntity, CustomerDto>), typeof(BaseService<Customer, CustomerEntity, CustomerDto>));
builder.Services.AddScoped<Func<CustomerEntity, Customer>>(p => (entity) => CustomerFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Customer, CustomerEntity>>(p => (model) => CustomerFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<CustomerDto, CustomerEntity>>(p => (dto) => CustomerFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
