using Business.Models;
using System.ComponentModel.DataAnnotations;

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
    public int StatusInformationId { get; set; }
    public string StatusInformation { get; set; } = null!;


    [Required]
    public int CustomerId { get; set; }
    public string Customer { get; set; } = null!;


    [Required]
    public int EmployeeId { get; set; }
    public string Employee { get; set; } = null!;


    [Required]
    public int ServiceId { get; set; }
    public string Service { get; set; } = null!;
}
