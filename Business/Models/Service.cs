using Business.Dtos;

namespace Business.Models;

public class Service
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public decimal Price { get; set; }
    public UnitDto Unit { get; set; } = null!;
}
