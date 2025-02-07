using Business.Dtos;
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

        var expression = _roleService.CreateExpressionAsync("Id", dto.RoleName);
        bool exists = await _roleService.AlreadyExistsAsync(expression);
        if (exists) return BadRequest("A role with that name already exists.");

        Role role = await _roleService.CreateAsync(dto);
        if (role == null) return BadRequest("Failed to create role.");

        return Ok(role);
    }
}
