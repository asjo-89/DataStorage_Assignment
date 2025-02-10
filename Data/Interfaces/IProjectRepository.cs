using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<ICollection<ProjectEntity>> GetAllProjectsAsync();
    Task<ProjectEntity> GetProjectAsync(int id);
}
