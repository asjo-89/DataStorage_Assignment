using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectDto Create() => new();

        public static Project CreateModelFromDto(ProjectDto dto) => new()
        {
            Id = dto.Id,
            Title = dto.Title,
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
            ProjectTitle = dto.Title,
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
            ProjectTitle = model.Title,
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
            Title = entity.ProjectTitle,
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
                CustomerName = entity.Customer.CustomerName
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
            Title = model.Title,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            StatusInformationId = model.StatusInformationId,
            StatusInformation = model.StatusInformation.StatusName,
            CustomerId = model.CustomerId,
            Customer = model.Customer.CustomerName,
            EmployeeId = model.EmployeeId,
            Employee = $"{model.Employee.FirstName} {model.Employee.LastName}",
            ServiceId = model.ServiceId,
            Service = $"{model.Service.ServiceName} {model.Service.Price} {model.Service.Unit}"
        };
    }
}
