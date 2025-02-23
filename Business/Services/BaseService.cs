using Business.Interfaces;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class BaseService<TModel, TEntity, TDto>(IBaseRepository<TEntity> repository,
    Func<TDto, TEntity> dtoToEntity, Func<TEntity, TModel> entityToModel, Func<TModel, TEntity> modelToEntity)
    : IBaseService<TModel, TEntity, TDto> where TModel : class where TDto : class where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository = repository;
    protected readonly Func<TDto, TEntity> _dtoToEntity = dtoToEntity;
    protected readonly Func<TEntity, TModel> _entityToModel = entityToModel;
    protected readonly Func<TModel, TEntity> _modelToEntity = modelToEntity;


    public virtual async Task<TModel> CreateAsync(TDto dto)
    {
        if (dto == null) return null!;

        TEntity entity = _dtoToEntity(dto);
        try
        {
            await _repository.BeginTransactionAsync();

            TEntity entry = await _repository.CreateAsync(entity);
            if (entry == null) return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            TModel model = _entityToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to create: {ex.Message}");
            return null!;
        }
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync()
    {
        IEnumerable<TEntity>? entities = await _repository.GetAllAsync();
        List<TModel> models = entities.Select(e => _entityToModel(e)).ToList() ?? [];
        return models ?? [];
    }

    public virtual async Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        TEntity? entity = await _repository.GetOneAsync(expression);
        if (entity == null) return null!;
        TModel model = _entityToModel(entity);

        return model ?? null!;
    }

    public async Task<TModel> UpdateAsync(TModel model)
    {
        if (model == null) return null!;

        try
        {
            await _repository.BeginTransactionAsync();

            TEntity entity = _modelToEntity(model);
            TEntity? updatedEntity = _repository.UpdateAsync(entity);
            if (updatedEntity == null) return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            TModel updatedModel = _entityToModel(entity);
            return updatedModel ?? null!;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to update: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(TModel model)
    {
        if (model == null) return false;

        try
        {
            await _repository.BeginTransactionAsync();

            TEntity entity = _modelToEntity(model);
            if (entity == null) return false;

            _repository.DeleteAsync(entity);

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            return true;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to delete: {ex.Message}");
            return false;
        }
    }
}