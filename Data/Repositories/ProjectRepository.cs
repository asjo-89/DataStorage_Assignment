using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DbContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DbContext _context = context;
}
