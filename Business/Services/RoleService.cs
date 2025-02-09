using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services
{
    public class RoleService(IBaseRepository<RoleEntity> repository)
    : BaseService<Role, RoleEntity, RoleDto>(repository, RoleFactory.CreateModelFromEntity, RoleFactory.CreateEntityFromModel, RoleFactory.CreateEntityFromDto), IRoleService
    {
        public override async Task<Role> CreateAsync(RoleDto dto)
        {
            if (await _repository.ExistsAsync(r => r.RoleName == dto.RoleName))
            {
                Debug.WriteLine("An employee with the same name already exists.");
                return null!;
            }

            Role role = await base.CreateAsync(dto);
            return role ?? null!;
        }
    }
}
