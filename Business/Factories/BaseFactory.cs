namespace Business.Factories;

public static class BaseFactory
{
    public static TModel CreateModelFromEntity<TModel, TEntity, TDto>(TEntity entity, Func<TEntity, TModel> entityToModelFactory)
        where TModel : class where TEntity : class
    {
        if (entity == null) return null!;

        return entityToModelFactory(entity);
    }

    public static TEntity CreateEntityFromModel<TEntity, TModel>(TModel model, Func<TModel, TEntity> modelToEntityFactory)
        where TModel : class where TEntity : class
    {
        if (model == null) return null!;

        return modelToEntityFactory(model);
    }
    public static TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto, Func<TDto, TEntity> dtoToEntityFactory)
       where TDto : class where TEntity : class
    {
        if (dto == null) return null!;

        return dtoToEntityFactory(dto);
    }
}
