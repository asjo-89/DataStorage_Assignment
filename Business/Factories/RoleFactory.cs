using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static RoleRegForm Create() => new();

    public static RoleEntity Create(RoleRegForm dto) => new()
    {
        RoleName = dto.RoleName
    };

    public static Role Create(RoleEntity entity) => new()
    {
        Id = entity.Id,
        RoleName = entity.RoleName
    };
    public static RoleEntity Create(Role model) => new()
    {
        Id = model.Id,
        RoleName = model.RoleName
    };
}


