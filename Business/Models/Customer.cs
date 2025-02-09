using Business.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;
    [Required]
    public string PhoneNumber { get; set; } = null!; 
    public string? Email { get; set; }
    public IEnumerable<Project> Projects { get; set; } = [];
}
