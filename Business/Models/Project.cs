using Business.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
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
    public StatusInformation StatusInformation { get; set; } = null!;

    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    [Required]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;   

    [Required]
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
