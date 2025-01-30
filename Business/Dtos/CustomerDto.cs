using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;

    [Required]
    public List<PhoneNumberDto> PhoneNumbers { get; set; } = [];

    public List<EmailDto>? Emails { get; set; } = [];
}
