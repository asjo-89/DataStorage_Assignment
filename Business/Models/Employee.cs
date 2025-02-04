using Business.Dtos;

namespace Business.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public RoleDto Role {  get; set; } = null!;
}
