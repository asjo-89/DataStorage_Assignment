using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TModel, TEntity, TDto>
    where TModel : class where TEntity : class where TDto : class
{
    Task<TModel> CreateAsync(TDto dto);
    Task<ICollection<TModel>> GetAllAsync();
    Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression);
    Task<TModel> UpdateAsync(TModel model);
    Task<bool> DeleteAsync(TModel model);
    //Task<bool> AlreadyExistsAsync(Expression<Func<TModel, bool>> expression);
}





//using System.Linq.Expressions;

//namespace Business.Interfaces;


////public interface IBaseService<TModel> where TModel : class
////{
////    Task<TModel> CreateAsync(TModel model);
////    Task<IEnumerable<TModel>> GetAllAsync();
////    Task<bool> ExistsAsync(Expression<Func<TModel, bool>> expression);
////    Task<TModel?> GetAsync(int id);
////    Task<TModel> UpdateAsync(TModel model);
////    Task<bool> DeleteAsync(int id);
////}

//public interface IBaseService<TModel TDto>
//    where TModel : class where TEntity : class where TDto : class
//{
//    Task<TModel> CreateAsync(TDto dto);
//    Task<ICollection<TModel>> GetAllAsync();
//    Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression);
//    Task<bool> UpdateAsync(int id, TModel model);
//    Task<bool> DeleteAsync(int id);
//    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
//    Expression<Func<TEntity, bool>> CreateExpressionAsync(string field, string value);
//}
