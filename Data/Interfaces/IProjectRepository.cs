using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<ProjectEntity> GetWithDetailsAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<IEnumerable<ProjectEntity>> GetAllWithDetailsAsync();



    //    Task<ICollection<ProjectEntity>> GetAllProjectsAsync();
    //    Task<ProjectEntity> GetProjectAsync(int id);
}
