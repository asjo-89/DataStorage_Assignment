using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;


[Index(nameof(ServiceName), IsUnique = true)]
public class ServiceEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ServiceName { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Guid UnitId { get; set; }



    public UnitEntity Unit { get; set; } = null!;
    public ICollection<ProjectEntity>? Projects { get; set; } = [];
}
