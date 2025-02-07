using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TModel, TEntity, TDto> 
    where TModel : class where TEntity : class where TDto : class
{
    Task<TModel> CreateAsync(TDto dto);
    Task<ICollection<TModel>> GetAllAsync();
    Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> UpdateAsync(int id, TModel model);
    Task<bool> DeleteAsync(int id);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
    Expression<Func<TEntity, bool>> CreateExpressionAsync(string field, string value);
}
