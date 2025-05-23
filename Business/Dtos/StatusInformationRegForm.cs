using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class StatusInformationRegForm
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "Status name is required.")]
    [StringLength(20, ErrorMessage = "Status name can only be 20 characters long.")]
    public string StatusName { get; set; } = null!; 
}
