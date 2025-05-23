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


builder.Services.AddScoped(typeof(IBaseService<Customer,CustomerEntity, CustomerRegForm>), typeof(BaseService<Customer, CustomerEntity, CustomerRegForm>));
builder.Services.AddScoped<Func<CustomerEntity, Customer>>(p => (entity) => CustomerFactory.Create(entity));
builder.Services.AddScoped<Func<Customer, CustomerEntity>>(p => (model) => CustomerFactory.Create(model));
builder.Services.AddScoped<Func<CustomerRegForm, CustomerEntity>>(p => (dto) => CustomerFactory.CreateEntityFromDto(dto));

builder.Services.AddScoped(typeof(IBaseService<Employee, EmployeeEntity, EmployeeRegForm>), typeof(BaseService<Employee, EmployeeEntity, EmployeeRegForm>));
builder.Services.AddScoped<Func<EmployeeEntity, Employee>>(p => (entity) => EmployeeFactory.Create(entity));
builder.Services.AddScoped<Func<Employee, EmployeeEntity>>(p => (model) => EmployeeFactory.Create(model));
builder.Services.AddScoped<Func<EmployeeRegForm, EmployeeEntity>>(p => (dto) => EmployeeFactory.Create(dto));

builder.Services.AddScoped(typeof(IBaseService<Role, RoleEntity, RoleRegForm>), typeof(BaseService<Role, RoleEntity, RoleRegForm>));
builder.Services.AddScoped<Func<RoleEntity, Role>>(p => (entity) => RoleFactory.Create(entity));
builder.Services.AddScoped<Func<Role, RoleEntity>>(p => (model) => RoleFactory.Create(model));
builder.Services.AddScoped<Func<RoleRegForm, RoleEntity>>(p => (dto) => RoleFactory.Create(dto));

builder.Services.AddScoped(typeof(IBaseService<Service, ServiceEntity, ServiceRegForm>), typeof(BaseService<Service, ServiceEntity, ServiceRegForm>));
builder.Services.AddScoped<Func<ServiceEntity, Service>>(p => (entity) => ServiceFactory.Create(entity));
builder.Services.AddScoped<Func<Service, ServiceEntity>>(p => (model) => ServiceFactory.Create(model));
builder.Services.AddScoped<Func<ServiceRegForm, ServiceEntity>>(p => (dto) => ServiceFactory.Create(dto));

builder.Services.AddScoped(typeof(IBaseService<StatusInformation, StatusInformationEntity, StatusInformationRegForm>), typeof(BaseService<StatusInformation, StatusInformationEntity, StatusInformationRegForm>));
builder.Services.AddScoped<Func<StatusInformationEntity, StatusInformation>>(p => (entity) => StatusInformationFactory.Create(entity));
builder.Services.AddScoped<Func<StatusInformation, StatusInformationEntity>>(p => (model) => StatusInformationFactory.Create(model));
builder.Services.AddScoped<Func<StatusInformationRegForm, StatusInformationEntity>>(p => (dto) => StatusInformationFactory.Create(dto));

builder.Services.AddScoped(typeof(IBaseService<Project, ProjectEntity, ProjectRegForm>), typeof(BaseService<Project, ProjectEntity, ProjectRegForm>));
builder.Services.AddScoped<Func<ProjectEntity, Project>>(p => (entity) => ProjectFactory.Create(entity));
builder.Services.AddScoped<Func<Project, ProjectEntity>>(p => (model) => ProjectFactory.Create(model));
builder.Services.AddScoped<Func<ProjectRegForm, ProjectEntity>>(p => (dto) => ProjectFactory.Create(dto));



builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<IStatusInformationService, StatusInformationService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


//var AllowedConnections = "_allowedConnections";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: AllowedConnections,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:5174", "http://localhost:5173")
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});

var app = builder.Build();

    app.MapOpenApi();


app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
