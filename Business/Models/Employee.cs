using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public IEnumerable<Project> Projects { get; set; } = [];
}
