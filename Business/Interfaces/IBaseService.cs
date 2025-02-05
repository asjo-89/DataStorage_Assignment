using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TModel, TEntity> where TModel : class where TEntity : class
{
    Task<ICollection<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> expression, TModel model);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
}
