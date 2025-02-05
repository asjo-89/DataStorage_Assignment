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
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Status = dto.Status,
            Customer = dto.Customer,
            Employee = dto.Employee,
            Service = dto.Service
        };

        public static ProjectDto CreateDtoFromModel(Project model) => new()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Status = model.Status,
            Customer = model.Customer,
            Employee = model.Employee,
            Service = model.Service
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
