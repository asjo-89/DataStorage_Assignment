using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;


[Index(nameof(ServiceName), IsUnique = true)]
public class ServiceEntity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ServiceName { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int UnitId { get; set; }



    public UnitEntity Unit { get; set; } = null!;
    public ICollection<ProjectEntity>? Projects { get; set; } = [];
}
