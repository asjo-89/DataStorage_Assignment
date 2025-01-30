using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class PhoneNumberDto
{
    public int Id { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = null!;
}
