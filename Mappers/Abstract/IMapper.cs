namespace Mappers
{
    public interface IMapper<TEntity, TModel>
    {
        public TEntity MapToEntity(TModel model);

        public TModel MapToModel(TEntity entity);
    }
}