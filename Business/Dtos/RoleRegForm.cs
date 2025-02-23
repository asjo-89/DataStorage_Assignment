using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class RoleRegForm
{
    public int Id { get; set; }

    [Required]
    public string RoleName { get; set; } = null!;
}
