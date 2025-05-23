using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerRegForm
{
    //public int? Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name can only be 50 characters long.")]
    public string CustomerName { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(20, ErrorMessage = "Phone number can only be 20 characters long.")]
    //[RegularExpression(@"^(?:\+46|0046|046)[0-9\s\-]{3,17}$", ErrorMessage = "Accepted format includes landcode, numbers 0-9, special characters +, - and space.")]

    public string PhoneNumber { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid format. Accepted formats: x.x@xx.xx, x-x@xx.xx, x_x@xx.xx.")]
    [StringLength(200, ErrorMessage = "Email address can only be 200 characters long.")]
    public string? Email { get; set; }

    public IEnumerable<ProjectRegForm>? Projects { get; set; }
}
