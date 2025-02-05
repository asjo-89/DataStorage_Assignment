using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto Create() => new();

        public static Employee CreateModelFromDto(EmployeeDto dto) => new()
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleName = dto.RoleName
        };

        public static EmployeeDto CreateDtoFromModel(Employee model) => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            RoleName = model.RoleName
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
            RoleName = entity.Role.RoleName
        };
    }
}
