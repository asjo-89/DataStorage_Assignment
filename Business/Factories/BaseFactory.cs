namespace Business.Factories;

public static class BaseFactory
{
    public static TModel CreateModelFromEntity<TModel, TEntity>(TEntity entity, Func<TEntity, TModel> entityFactory)
        where TModel : class where TEntity : class
    {
        if (entity == null) return null!;

        return entityFactory(entity);
    }

    public static TEntity CreateEntityFromModel<TEntity, TModel>(TModel model, Func<TModel, TEntity> modelFactory)
        where TModel : class where TEntity : class
    {
        if (model == null) return null!;

        return modelFactory(model);
    }
}
