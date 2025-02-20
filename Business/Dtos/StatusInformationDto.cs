using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class StatusInformationDto
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string StatusName { get; set; } = null!; 
}
