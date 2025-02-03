using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(EmailAddress), IsUnique = true)]
public class EmailAddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    [EmailAddress]
    [RegularExpression(@"^(?!\.)[a-zA-Z0-9][a-zA-Z0-9._%+-]{0,63}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string EmailAddress { get; set; } = null!;

    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;
}


