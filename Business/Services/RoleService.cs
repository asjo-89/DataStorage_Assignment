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
    : BaseService<Role, RoleEntity, RoleDto>(repository, 
        RoleFactory.CreateModelFromEntity, 
        RoleFactory.CreateEntityFromModel, 
        RoleFactory.CreateEntityFromDto), 
    IRoleService
    {
    }
}
