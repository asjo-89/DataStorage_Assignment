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

    public async Task<ICollection<EmployeeEntity>> GetEmployeesWithDetailsAsync()
    {
        return await _context.Employees
            .Include(e => e.Role)
            .Include(e => e.Projects)
            .ToListAsync();
    }

    public async Task<ICollection<EmployeeEntity>> GetEmployeesWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        return await _context.Employees
            .Where(expression)
            .Include(e => e.Role)
            .Include(e => e.Projects)
            .ToListAsync();
    }
}
