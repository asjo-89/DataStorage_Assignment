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
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IStatusInformationRepository, StatusInformationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();


builder.Services.AddScoped(typeof(IBaseService<Customer, CustomerEntity, CustomerDto>), typeof(BaseService<Customer, CustomerEntity, CustomerDto>));
builder.Services.AddScoped<Func<CustomerEntity, Customer>>(p => (entity) => CustomerFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Customer, CustomerEntity>>(p => (model) => CustomerFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<CustomerDto, CustomerEntity>>(p => (dto) => CustomerFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<Employee, EmployeeEntity, EmployeeDto>), typeof(BaseService<Employee, EmployeeEntity, EmployeeDto>));
builder.Services.AddScoped<Func<EmployeeEntity, Employee>>(p => (entity) => EmployeeFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Employee, EmployeeEntity>>(p => (model) => EmployeeFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<EmployeeDto, EmployeeEntity>>(p => (dto) => EmployeeFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<Role, RoleEntity, RoleDto>), typeof(BaseService<Role, RoleEntity, RoleDto>));
builder.Services.AddScoped<Func<RoleEntity, Role>>(p => (entity) => RoleFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Role, RoleEntity>>(p => (model) => RoleFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<RoleDto, RoleEntity>>(p => (dto) => RoleFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<Service, ServiceEntity, ServiceDto>), typeof(BaseService<Service, ServiceEntity, ServiceDto>));
builder.Services.AddScoped<Func<ServiceEntity, Service>>(p => (entity) => ServiceFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Service, ServiceEntity>>(p => (model) => ServiceFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<ServiceDto, ServiceEntity>>(p => (dto) => ServiceFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<StatusInformation, StatusInformationEntity, StatusInformationDto>), typeof(BaseService<StatusInformation, StatusInformationEntity, StatusInformationDto>));
builder.Services.AddScoped<Func<StatusInformationEntity, StatusInformation>>(p => (entity) => StatusInformationFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<StatusInformation, StatusInformationEntity>>(p => (model) => StatusInformationFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<StatusInformationDto, StatusInformationEntity>>(p => (dto) => StatusInformationFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<Project, ProjectEntity, ProjectDto>), typeof(BaseService<Project, ProjectEntity, ProjectDto>));
builder.Services.AddScoped<Func<ProjectEntity, Project>>(p => (entity) => ProjectFactory.CreateModelFromEntity(entity));
builder.Services.AddScoped<Func<Project, ProjectEntity>>(p => (model) => ProjectFactory.CreateEntityFromModel(model));
builder.Services.AddScoped<Func<ProjectDto, ProjectEntity>>(p => (dto) => ProjectFactory.CreateEntityFromDto(dto));



builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<IStatusInformationService, StatusInformationService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var AllowedConnections = "_allowedConnections";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowedConnections,
        policy =>
        {
            policy.WithOrigins("http://localhost:5174", "http://localhost:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(AllowedConnections);

app.UseAuthorization();

app.MapControllers();

app.Run();
