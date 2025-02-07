using Business.Dtos;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!; 
    public string? Email { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
}
