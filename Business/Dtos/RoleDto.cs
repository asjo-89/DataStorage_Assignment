using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class RoleDto
{
    public Guid Id { get; set; }

    [Required]
    public string RoleName { get; set; } = null!;
}
