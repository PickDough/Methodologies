namespace Mappers
{
    public interface IDomainModelMapper<TDomain, TModel>
    {
        public TDomain MapToDomain(TModel model);

        public TModel MapToModel(TDomain domain);
    }
}