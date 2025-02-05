using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UnitDto
{
    public Guid Id { get; set; }

    [Required]
    public string Unit { get; set; } = null!;
}
