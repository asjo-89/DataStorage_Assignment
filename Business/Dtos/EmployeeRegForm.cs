using Business.Services;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeRegForm
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public int RoleId { get; set; }

    public IEnumerable<ProjectRegForm>? Projects { get; set; }
}
