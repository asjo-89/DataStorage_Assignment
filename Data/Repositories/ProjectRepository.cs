using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DbContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
}
