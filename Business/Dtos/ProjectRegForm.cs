using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectRegForm
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string ProjectTitle { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string Description { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    public DateTime? StartDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
    public DateTime? EndDate { get; set; }


    [Required]
    public int StatusInformationId { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    //public StatusInformationRegForm? StatusInformation { get; set; }


    [Required]
    public int CustomerId { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    //public CustomerRegForm? Customer { get; set; }


    [Required]
    public int EmployeeId { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    //public EmployeeRegForm? Employee { get; set; }


    [Required]
    public int ServiceId { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    //public ServiceRegForm? Service { get; set; }
}
