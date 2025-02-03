using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ProjectTitle { get; set; } = null!;

    [Column(TypeName = "nvarchar(300)")]
    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    [ForeignKey(nameof(StatusInformation))]
    public int StatusId { get; set; }

    [Required]
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [Required]
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }

    [Required]
    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }


    public CustomerEntity Customer { get; set; } = null!;
    public EmployeeEntity Employee { get; set; } = null!;
    public StatusInformationEntity StatusInformation { get; set; } = null!;
    public ServiceEntity Service { get; set; } = null!;
}
