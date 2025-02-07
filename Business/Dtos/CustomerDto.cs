using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }
}
