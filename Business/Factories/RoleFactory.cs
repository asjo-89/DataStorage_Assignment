using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static RoleDto Create() => new();

    public static RoleEntity CreateEntityFromDto(RoleDto dto) => new()
    {
        RoleName = dto.RoleName
    };

    public static Role CreateModelFromEntity(RoleEntity entity) => new()
    {
        Id = entity.Id,
        RoleName = entity.RoleName
    };
    public static RoleEntity CreateEntityFromModel(Role model) => new()
    {
        Id = model.Id,
        RoleName = model.RoleName
    };
}
