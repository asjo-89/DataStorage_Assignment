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
            StatusId = dto.StatusId,
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
            StatusId = model.StatusInformationId,
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
            Status = entity.StatusInformation.StatusName,
            Customer = entity.Customer.CustomerName,
            Employee = $"{entity.Employee.FirstName} {entity.Employee.LastName}",
            Service = entity.Service.ServiceName
        };
    }
}
