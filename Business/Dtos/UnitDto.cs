using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UnitDto
{
    public int Id { get; set; }

    [Required]
    public string Unit { get; set; } = null!;
}
