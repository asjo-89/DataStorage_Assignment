using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectRegForm
{
    [Required]
    public string ProjectTitle { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    public DateTime? StartDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    public DateTime? EndDate { get; set; }


    [Required]
    public int StatusInformationId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int ServiceId { get; set; }
}
