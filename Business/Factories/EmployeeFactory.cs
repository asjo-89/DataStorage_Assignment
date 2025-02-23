
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeRegForm Create() => new();

        public static EmployeeEntity Create(EmployeeRegForm dto) => new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId
        };

        public static EmployeeEntity Create(Employee model) => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            RoleId = model.RoleId,
            Role = new RoleEntity
            {
                Id = model.RoleId,
                RoleName = model.Role.RoleName
            }
        };

        public static Employee Create(EmployeeEntity entity) => new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            RoleId = entity.RoleId,
            Role = new Role
            {
                Id = entity.RoleId,
                RoleName = entity.Role.RoleName
            },
            Projects = entity.Projects.Select(p => new Project
            {
                Id = p.Id,
                ProjectTitle = p.ProjectTitle,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                StatusInformationId = p.StatusInformationId,
                CustomerId = p.CustomerId
            }).ToList()
        };
    }
}
