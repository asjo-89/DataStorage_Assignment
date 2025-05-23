using Business.Services;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeRegForm
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(20, ErrorMessage = "First name can only be 30 characters long.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name can only be 50 characters long.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Role is required.")]
    public int RoleId { get; set; }

    public IEnumerable<ProjectRegForm>? Projects { get; set; }
}
