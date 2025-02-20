using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerRegForm
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string CustomerName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(\+46|0)\s?(7[02369]\d|8\d|1\d{2})\s?\d{3}\s?\d{2}\?\d{2}$")]
    public string PhoneNumber { get; set; } = null!;

    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+\\-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string? Email { get; set; }

    public IEnumerable<ProjectRegForm>? Projects { get; set; }
}
