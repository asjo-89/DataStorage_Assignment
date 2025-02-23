using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TModel, TEntity, TDto>
    where TModel : class where TEntity : class where TDto : class
{
    Task<TModel> CreateAsync(TDto dto);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    Task<TModel> UpdateAsync(TModel model);
    Task<bool> DeleteAsync(TModel model);
}



