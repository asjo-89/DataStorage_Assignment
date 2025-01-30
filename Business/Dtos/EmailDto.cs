using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmailDto
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^(?!\.)[a-zA-Z0-9][a-zA-Z0-9._%+-]{0,63}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
