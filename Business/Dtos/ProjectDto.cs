﻿using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectDto
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public string Status { get; set; } = null!;
    public int StatusId { get; set; }

    [Required]
    public string Customer { get; set; } = null!;
    public int CustomerId { get; set; }

    [Required]
    public string Employee { get; set; } = null!;
    public int EmployeeId { get; set; }

    [Required]
    public string Service { get; set; } = null!;
    public int ServiceId { get; set; }
}
