using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class StatusInformationDto
{
    public Guid Id { get; set; }

    [Required]
    public string StatusName { get; set; } = null!; 
}
