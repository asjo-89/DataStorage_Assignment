using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceDto
{
    public int Id { get; set; }

    [Required]

    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string ServiceName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$")]
    public decimal Price { get; set; }

    [Required]
    [RegularExpression(@"^(?i)([A-Za-z]{2,})(\/(tim(?:me)?|dag(?:ar)?))?$")]
    public string Unit { get; set; } = null!;
}
