using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectDto
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
    public StatusInformationDto? StatusInformation { get; set; }


    [Required]
    public int CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }


    [Required]
    public int EmployeeId { get; set; }
    public EmployeeDto? Employee { get; set; }


    [Required]
    public int ServiceId { get; set; }
    public ServiceDto? Service { get; set; }
}
