using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{
    public async Task<EmployeeEntity> GetEmployeeWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        return await _context.Employees
            .Include(e => e.Role)
            .Include(e => e.Projects)
            .FirstOrDefaultAsync(expression) ?? null!;
    }
}
