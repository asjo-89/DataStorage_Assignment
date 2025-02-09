using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceDto
{
    public int Id { get; set; }

    [Required]
    public string ServiceName { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int UnitId {  get; set; }

    public UnitDto? Unit { get; set; }
}
