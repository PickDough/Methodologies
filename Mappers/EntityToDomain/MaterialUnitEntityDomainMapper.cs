using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class MaterialUnitEntityDomainMapper: IMaterialUnitEntityDomainMapper
    {
        public MaterialUnitEntity MapToEntity(MaterialUnit domain)
        {
            return new ()
            {
                Id = domain.Id,
                UnitName = domain.UnitName
            };
        }

        public MaterialUnit MapToDomain(MaterialUnitEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                UnitName = entity.UnitName
            };
        }
    }
}