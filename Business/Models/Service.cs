using Business.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Service
{
    public int Id { get; set; }
    [Required]
    public string ServiceName { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public UnitDto Unit { get; set; } = null!;
}
