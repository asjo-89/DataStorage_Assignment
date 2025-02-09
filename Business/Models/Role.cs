using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Role
{
    public int Id { get; set; }
    [Required]
    public string RoleName { get; set; } = null!;
}
