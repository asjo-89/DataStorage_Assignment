using Business.Services;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class EmployeeRegForm
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string FirstName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string LastName { get; set; } = null!;

    [Required]
    public int RoleId { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    //public string? RoleName { get; set; }

    public IEnumerable<ProjectRegForm>? Projects { get; set; }
}
