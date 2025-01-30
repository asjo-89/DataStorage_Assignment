using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    // Create
    Task<TEntity> CreateAsync(TEntity entity);

    //Read
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

    //Update
    Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity);

    //Delete
    Task<bool> DeleteAsync(int id);
}
