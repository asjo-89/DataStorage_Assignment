using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Business.Services;



public class BaseService<TModel, TEntity, TDto>(IBaseRepository<TEntity> repository, 
    Func<TEntity, TModel> modelFromEntity, Func<TModel, TEntity> entityFromModel, Func<TDto, TEntity> entityFromDto)
    : IBaseService<TModel, TEntity, TDto> where TModel : class where TEntity : class, IEntity where TDto : class
{
    protected readonly IBaseRepository<TEntity> _repository = repository;
    protected readonly Func<TEntity, TModel> _modelFromEntity = modelFromEntity;
    protected readonly Func<TModel, TEntity> _entityFromModel = entityFromModel;
    protected readonly Func<TDto, TEntity> _entityFromDto = entityFromDto;


    public virtual async Task<TModel> CreateAsync(TDto dto)
    {
        if (dto == null) return null!;

        var entity = _entityFromDto(dto);
        var createdEntity = await _repository.CreateAsync(entity);
        return createdEntity != null ? _modelFromEntity(createdEntity) : null!;
    }

    public virtual async Task<ICollection<TModel>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => _modelFromEntity(e)).ToList() ?? [];
    }

    public async Task<TModel> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _repository.GetOneAsync(expression);
        return entity != null ? _modelFromEntity(entity) : null!;
    }

    public virtual async Task<bool> UpdateAsync(int id, TModel model)
    {
        try
        {
            if (model != null)
            {
                var entity = _entityFromModel(model);
                var updatedEntity = await _repository.UpdateAsync(id, entity);
                return updatedEntity != null ? true : false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to update :: {ex.Message}");
        }
        return false;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            if (id != 0)
            {
                return await _repository.DeleteAsync(id);
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
        if (expression == null) return true;

        return await _repository.ExistsAsync(expression);
    }

    // Nedan är genererat av ChatGPT men jag har anpassat den till min applikation.
    // Används för att kunna generera ett expression
    // för att kunna använda de generiska metoderna i controllern
    // baserat på vad användaren valt att söka på, såsom id, name, projecttitle etc.
    public Expression<Func<TEntity, bool>> CreateExpressionAsync(string field, string value)
    {
        // Sätter namnet på entiteten till x som används i expression
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        // Hämtar och matchar fältet i TEntity mot "field" som skickats in i metoden.
        var property = typeof(TEntity).GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (property == null) return null!;

        // Konverterar värdet på söksträngen value till samma typ som det är på fältet i entiteten.
        var searchValue = Convert.ChangeType(value, property.PropertyType);
        // Skapar jämförelsen i expression (x.Name = name).
        var comparison = Expression.Equal(Expression.Property(parameter, property), Expression.Constant(searchValue));
        // Returnerar ett färdig expression.
        return Expression.Lambda<Func<TEntity, bool>>(comparison, parameter);
    }
}

