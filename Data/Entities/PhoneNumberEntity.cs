using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(PhoneNumber), IsUnique = true)]
public class PhoneNumberEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;
}
