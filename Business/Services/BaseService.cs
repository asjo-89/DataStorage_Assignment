using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Data.Migrations;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class BaseService<TModel, TEntity>(IBaseRepository<TEntity> repository, Func<TEntity, TModel> entityToModel, Func<TModel, TEntity> modelToEntity) 
    : IBaseService<TModel, TEntity> where TModel : class where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository = repository;
    protected readonly Func<TEntity, TModel> _entityToModel = entityToModel;
    protected readonly Func<TModel, TEntity> _modelToEntity = modelToEntity;



    public async Task<ICollection<TModel>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => _entityToModel(e)).ToList();
    }

    public async Task<TModel> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity != null ? _entityToModel(entity) : null!;
    }

    public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> expression, TModel model)
    {
        try
        {
            if (expression != null && model != null)
            {
                var entity = _modelToEntity(model);
                var updatedEntity = await _repository.UpdateAsync(expression, entity);
                return updatedEntity ? true : false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to update :: {ex.Message}");
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            if (expression != null)
            {
                return await _repository.DeleteAsync(expression);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to delete :: {ex.Message}");
        }
        return false;
    }

    public async Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        if ( expression == null ) return false; 

        return await _repository.ExistsAsync(expression);
    }
}
