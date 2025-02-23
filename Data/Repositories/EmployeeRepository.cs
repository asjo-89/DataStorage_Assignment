using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{
    public async Task<EmployeeEntity> GetWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        return await _context.Employees
            .Include(e => e.Role)
            .Include(e => e.Projects)
                .ThenInclude(p => p.Customer)
            .Include(e => e.Projects)
                .ThenInclude(p => p.Service)
            .Include(e => e.Projects)
                .ThenInclude(p => p.StatusInformation)
            .FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<ICollection<EmployeeEntity>> GetAllWithDetailsAsync()
    {
        return await _context.Employees
            .Include(e => e.Role)
            .Include(e => e.Projects)
                .ThenInclude(p => p.StatusInformation)
            .ToListAsync() ?? [];
    }
}


