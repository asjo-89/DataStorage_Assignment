using Business.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }

    [Required]
    public string ProjectTitle { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public int StatusInformationId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int ServiceId { get; set; }


    public Customer Customer { get; set; } = null!;
    public StatusInformation StatusInformation { get; set; } = null!;
    public Employee Employee { get; set; } = null!;   
    public Service Service { get; set; } = null!;
}
