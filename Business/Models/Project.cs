using Business.Dtos;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusInformationDto Status { get; set; } = null!;
    public CustomerDto Customer { get; set; } = null!;
    public EmployeeDto Employee { get; set; } = null!;
    public ServiceDto Service { get; set; } = null!;
}
