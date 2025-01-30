using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

[Index(nameof(EmailAddress), IsUnique = true)]
public class EmailAddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [RegularExpression(@"^(?!\.)[a-zA-Z0-9][a-zA-Z0-9._%+-]{0,63}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string EmailAddress { get; set; } = null!;


    public CustomerEntity Customer { get; set; } = null!;
}


