using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Dtos;

public class CustomerDto
{
    //public Guid Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }
}
