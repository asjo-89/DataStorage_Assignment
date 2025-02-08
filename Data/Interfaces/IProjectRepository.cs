using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<ProjectEntity> GetProjectWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression);
}
