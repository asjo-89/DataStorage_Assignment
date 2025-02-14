using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
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

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _roleService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        Role role = await _roleService.GetOneAsync(x => x.Id == id);
        RoleDto dto = RoleFactory.CreateDtoFromModel(role);
        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id == 0) return BadRequest("Invalid id. No service was deleted.");

        var deleted = await _roleService.DeleteAsync(id);
        if (!deleted) return NotFound("No service was found.");

        return Ok("The service was successfully deleted.");
    }
}
