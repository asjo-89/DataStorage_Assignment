using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    //Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackAsync();
    //Task CreateAsync(TEntity entity);
    //Task<IEnumerable<TEntity>> GetAsync();
    //Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    //void UpdateAsync(TEntity entity);
    //void DeleteAsync(TEntity entity);
    Task<int> SaveChangesAsync();
}
