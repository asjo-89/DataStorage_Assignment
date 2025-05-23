using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceRegForm
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "Service name is required.")]
    [StringLength(30, ErrorMessage = "Service name can only be 30 characters long.")]
    public string ServiceName { get; set; } = null!;

    [Required(ErrorMessage = "Price is required.")]
    [RegularExpression(@"^[1-9]\d*(\.\d{1,2})?$", ErrorMessage = "Price cannot start with 0 and can only have two decimals.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Unit is required.")]
    [RegularExpression(@"^[a-zA-Z]{1,6}(\/[a-zA-Z]{1,6})?$", ErrorMessage = "Invalid format. Unit can have a maximum of 6 letters before aand after /. " +
        "Examples: xxxxxx/xxxxxx, xxxxxx")]        
    public string Unit { get; set; } = null!;
}
