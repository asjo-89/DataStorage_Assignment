using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class RoleRegForm
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "Role name is required.")]
    [StringLength(20, ErrorMessage = "Role name can only be 20 characters long.")]
    public string RoleName { get; set; } = null!;
}
