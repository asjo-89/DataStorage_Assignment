using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string CustomerName { get; set; } = null!;


    public ICollection<PhoneNumberEntity> PhoneNumbers { get; set; } = null!;
    public ICollection<EmailAddressEntity>? EmailAddresses { get; set; }
    public ICollection<ProjectEntity>? Projects { get; set; }
}
