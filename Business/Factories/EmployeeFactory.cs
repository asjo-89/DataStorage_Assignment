using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto Create() => new();

        public static EmployeeEntity CreateEntityFromDto(EmployeeDto dto) => new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId
        };

        public static EmployeeEntity CreateEntityFromModel(Employee model) => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            RoleId = model.RoleId
        };

        public static Employee CreateModelFromEntity(EmployeeEntity entity) => new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            RoleId = entity.RoleId,
            RoleName = entity.Role.RoleName,
            Projects = entity.Projects?.Select(p => new Project
            {
                Id = p.Id,
                Title = p.ProjectTitle,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Employee = $"{p.Employee.FirstName} {p.Employee.LastName}"
            }).ToList()
        };
    }
}
