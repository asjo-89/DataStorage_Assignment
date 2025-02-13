﻿using Business.Services;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public int RoleId { get; set; }
    public string? RoleName { get; set; }

    public IEnumerable<ProjectDto>? Projects { get; set; }
}
