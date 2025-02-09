using Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string CustomerName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }  


    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
