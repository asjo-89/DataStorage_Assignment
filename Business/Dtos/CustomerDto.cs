using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    public IEnumerable<ProjectDto>? Projects { get; set; }
}
