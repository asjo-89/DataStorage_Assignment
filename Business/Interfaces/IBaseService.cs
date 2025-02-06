using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TModel, TEntity, TDto> 
    where TModel : class where TEntity : class where TDto : class
{
    Task<TModel> CreateAsync(TDto dto);
    Task<ICollection<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, TModel model);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
    Expression<Func<TEntity, bool>> CreateExpressionAsync(string field, string value);
}
