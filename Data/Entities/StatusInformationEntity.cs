using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;


[Index(nameof(StatusName), IsUnique = true)]
public class StatusInformationEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string StatusName { get; set; } = null!;


    public ICollection<ProjectEntity>? Projects { get; set; } = [];
}
