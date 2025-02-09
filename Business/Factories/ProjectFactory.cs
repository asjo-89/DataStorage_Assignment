using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectDto Create() => new();

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
            CustomerId = entity.CustomerId,
            EmployeeId = entity.EmployeeId,
            ServiceId = entity.ServiceId
        };

        public static ProjectDto CreateDtoFromModel(Project model) => new()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            StatusInformation = $"{model.StatusInformation.StatusName}",
            Customer = $"{model.Customer.CustomerName}",
            Employee = $"{model.Employee.FirstName} {model.Employee.LastName}",
            Service = $"{model.Service.ServiceName} {model.Service.Price} {model.Service.Unit}"
        };
    }
}
