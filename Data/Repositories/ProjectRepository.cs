using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public async Task<ProjectEntity> GetProjectAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.Customer)
            .Include(p => p.Employee)
            .Include(p => p.Service)
            .Include(p => p.StatusInformation)
            .FirstOrDefaultAsync(p => p.Id == id) ?? null!;
    }

    public async Task<ICollection<ProjectEntity>> GetAllProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.Customer)
            .Include(p => p.Employee)
            .Include(p => p.Service)
            .Include(p => p.StatusInformation)
            .ToListAsync() ?? [];
    }
}
