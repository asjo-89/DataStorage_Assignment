using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmployeeRepository(DbContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{
    private readonly DbContext _context = context;
}
