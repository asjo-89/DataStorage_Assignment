using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeDto
{
    //public Guid Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public RoleDto RoleName { get; set; } = null!;
}
