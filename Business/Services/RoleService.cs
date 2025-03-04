﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services
{
    public class RoleService(IBaseRepository<RoleEntity> repository)
    : BaseService<Role, RoleEntity, RoleRegForm>(repository, 
        RoleFactory.Create, 
        RoleFactory.Create, 
        RoleFactory.Create), 
    IRoleService
    {
    }
}
