namespace Business.Factories;

public static class BaseFactory
{
    public static TModel CreateModelFromEntity<TModel, TEntity, TDto>(TEntity entity, Func<TEntity, TModel> modelFromEntity)
        where TModel : class where TEntity : class
    {
        if (entity == null) return null!;

        return modelFromEntity(entity);
    }

    public static TEntity CreateEntityFromModel<TEntity, TModel>(TModel model, Func<TModel, TEntity> entityFromModel)
        where TModel : class where TEntity : class
    {
        if (model == null) return null!;

        return entityFromModel(model);
    }
    public static TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto, Func<TDto, TEntity> entityFromDto)
       where TDto : class where TEntity : class
    {
        if (dto == null) return null!;

        return entityFromDto(dto);
    }
}
