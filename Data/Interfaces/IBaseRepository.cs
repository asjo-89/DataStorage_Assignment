using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
    // Create
    Task<TEntity> CreateAsync(TEntity entity);

    //Read
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetByPropertyAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

    //Update
    Task<bool> UpdateAsync(Guid id, TEntity entity);

    //Delete
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
}
