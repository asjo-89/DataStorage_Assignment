using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;


    [HttpPost]
    public async Task<IActionResult> CreateAsync(RoleDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.RoleName)) return BadRequest("No data available to create new role.");

        Role newRole = await _roleService.CreateAsync(dto);
        if (newRole == null) return BadRequest("Failed to create role.");

        return Ok(RoleFactory.CreateDtoFromModel(newRole));
    }
}
