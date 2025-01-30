using Business.Dtos;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public List<PhoneNumber> PhoneNumbers { get; set; } = [];
    public List<EmailAddress>? Emails { get; set; } = [];
}
