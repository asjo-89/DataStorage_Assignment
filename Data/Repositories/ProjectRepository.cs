using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public async Task<ProjectEntity> GetProjectWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _context.Projects
            .Include(e => e.Customer)
            .Include(e => e.Employee)
            .Include(e => e.Service)
            .Include(e => e.StatusInformation)
            .FirstOrDefaultAsync(expression) ?? null!;
    }
}
