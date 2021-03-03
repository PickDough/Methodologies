using Domain;
using Model;

namespace Mappers
{
    public class MaterialUnitDomainModelMapper: IMaterialUnitDomainModelnMapper
    {
        public MaterialUnit MapToDomain(MaterialUnitModel model)
        {
            return new ()
            {
                Id = model.Id,
                UnitName = model.UnitName
            };
        }

        public MaterialUnitModel MapToModel(MaterialUnit domain)
        {
            return new ()
            {
                Id = domain.Id,
                UnitName = domain.UnitName
            };
        }
    }
}