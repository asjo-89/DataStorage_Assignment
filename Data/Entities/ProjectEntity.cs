using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(ProjectTitle), IsUnique = true)]
public class ProjectEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ProjectTitle { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(300)")]
    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public Guid StatusId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public Guid EmployeeId { get; set; }

    [Required]
    public Guid ServiceId { get; set; }


    public CustomerEntity Customer { get; set; } = null!;
    public EmployeeEntity Employee { get; set; } = null!;
    public StatusInformationEntity StatusInformation { get; set; } = null!;
    public ServiceEntity Service { get; set; } = null!;
}
