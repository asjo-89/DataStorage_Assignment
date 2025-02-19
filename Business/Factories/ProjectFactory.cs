using Business.Dtos;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectDto Create() => new();

        public static Project CreateModelFromDto(ProjectDto dto) => new()
        {
            Id = dto.Id,
            ProjectTitle = dto.ProjectTitle,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            StatusInformationId = dto.StatusInformationId,
            CustomerId = dto.CustomerId,
            EmployeeId = dto.EmployeeId,
            ServiceId = dto.ServiceId
        };

        public static ProjectEntity CreateEntityFromDto(ProjectDto dto) => new()
        {
            ProjectTitle = dto.ProjectTitle,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            StatusInformationId = dto.StatusInformationId,
            CustomerId = dto.CustomerId,
            EmployeeId = dto.EmployeeId,
            ServiceId = dto.ServiceId
        };

        public static ProjectEntity CreateEntityFromModel(Project model) => new()
        {
            Id = model.Id,
            ProjectTitle = model.ProjectTitle,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            StatusInformationId = model.StatusInformationId,
            CustomerId = model.CustomerId,
            EmployeeId = model.EmployeeId,
            ServiceId = model.ServiceId
        };

        public static Project CreateModelFromEntity(ProjectEntity entity) => new()
        {
            Id = entity.Id,
            ProjectTitle = entity.ProjectTitle,
            Description = entity.Description!,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            StatusInformationId = entity.StatusInformationId,
            StatusInformation = new StatusInformation
            {
                Id = entity.StatusInformationId,
                StatusName = entity.StatusInformation.StatusName,
            },
            CustomerId = entity.CustomerId,
            Customer = new Customer
            {
                Id = entity.CustomerId,
                CustomerName = entity.Customer.CustomerName,
                PhoneNumber = entity.Customer.PhoneNumber,
                Email = entity.Customer?.Email
            },
            EmployeeId = entity.EmployeeId,
            Employee = new Employee
            {
                Id = entity.EmployeeId,
                FirstName = entity.Employee.FirstName,
                LastName = entity.Employee.LastName
            },
            ServiceId = entity.ServiceId,
            Service = new Service
            {
                Id= entity.ServiceId,
                ServiceName = entity.Service.ServiceName,
                Price = entity.Service.Price,
                Unit = entity.Service.Unit
            }
        };

        public static ProjectDto CreateDtoFromModel(Project model) => new()
        {
            Id = model.Id,
            ProjectTitle = model.ProjectTitle,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            StatusInformationId = model.StatusInformationId,
            StatusInformation = new StatusInformationDto
            {
                Id = model.StatusInformationId,
                StatusName = model.StatusInformation.StatusName,
            },
            CustomerId = model.CustomerId,
            Customer = new CustomerDto
            {
                Id = model.CustomerId,
                CustomerName = model.Customer.CustomerName,
                PhoneNumber = model.Customer.PhoneNumber,
                Email = model.Customer?.Email
            },
            EmployeeId = model.EmployeeId,
            Employee = new EmployeeDto
            {
                Id = model.EmployeeId,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName
            },
            ServiceId = model.ServiceId,
            Service = new ServiceDto
            {
                Id = model.ServiceId,
                ServiceName = model.Service.ServiceName,
                Price = model.Service.Price,
                Unit = model.Service.Unit
            }
        };
    }
}
