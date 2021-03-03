namespace Mappers
{
    public interface IEntityDomainMapper<TEntity, TDomain>
    {
        public TEntity MapToEntity(TDomain domain);

        public TDomain MapToDomain(TEntity entity);
    }
}