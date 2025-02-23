using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    public async Task<CustomerEntity> GetWithDetailsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        return await _context.Customers
            .Include(c => c.Projects)
                .ThenInclude(p => p.Employee)
                    .ThenInclude(e => e.Role)
            .FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllWithDetailsAsync()
    {
        return await _context.Customers
            .Include(c => c.Projects)
                .ThenInclude(p => p.Employee)
                    .ThenInclude(e => e.Role)
            .ToListAsync() ?? [];
    }
}


