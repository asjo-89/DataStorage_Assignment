using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Unit
{
    public int Id { get; set; }
    [Required]
    public string UnitName { get; set; } = null!;
}
