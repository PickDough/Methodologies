using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class MaterialTypeDomainModelMapper: IMaterialTypeDomainModelMapper
    {
        public MaterialType MapToDomain(MaterialTypeModel model)
        {
            return new ()
            {
                Id = model.Id,
                TypeName = model.TypeName
            };
        }

        public MaterialTypeModel MapToModel(MaterialType domain)
        {
            return new ()
            {
                Id = domain.Id,
                TypeName = domain.TypeName
            };
        }
    }
}