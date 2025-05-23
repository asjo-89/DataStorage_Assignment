using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectRegForm
{
    [Required(ErrorMessage = "Project title is required.")]
    public string ProjectTitle { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? StartDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? EndDate { get; set; }


    [Required(ErrorMessage = "Status is required.")]
    public int StatusInformationId { get; set; }

    [Required(ErrorMessage = "Customer is required.")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Employee is required.")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Service is required.")]
    public int ServiceId { get; set; }
}
