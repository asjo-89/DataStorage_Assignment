using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
    // Create
    Task<TEntity> CreateAsync(TEntity entity);

    //Read
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    //Task<TEntity> GetByPropertyAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

    //Update
    Task<TEntity?> UpdateAsync(TEntity entity);

    //Delete
    Task<bool> DeleteAsync(int id);
}
