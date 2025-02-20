using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class RoleRegForm
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string RoleName { get; set; } = null!;
}
