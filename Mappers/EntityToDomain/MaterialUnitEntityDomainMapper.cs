using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class MaterialUnitEntityDomainMapper
    {
        public static MaterialUnitEntity MapToEntity(MaterialUnit domain)
        {
            return new ()
            {
                Id = domain.Id,
                UnitName = domain.UnitName
            };
        }

        public static MaterialUnit MapToDomain(MaterialUnitEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                UnitName = entity.UnitName
            };
        }
    }
}