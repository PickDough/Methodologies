using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class MaterialEntityDomainMapper
    {
        public static MaterialEntity MapToEntity(Material domain)
        {
            return new ()
            {
                Id = domain.Id,
                PricePerUnit = domain.PricePerUnit,
                UnitsPerArea = domain.UnitsPerArea,
                MaterialType = MaterialTypeEntityDomainMapper.MapToEntity(domain.MaterialType),
                MaterialUnits = MaterialUnitEntityDomainMapper.MapToEntity(domain.MaterialUnits)
            };
        }

        public static Material MapToDomain(MaterialEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                PricePerUnit = entity.PricePerUnit,
                UnitsPerArea = entity.UnitsPerArea,
                MaterialType = MaterialTypeEntityDomainMapper.MapToDomain(entity.MaterialType),
                MaterialUnits = MaterialUnitEntityDomainMapper.MapToDomain(entity.MaterialUnits)
            };
        }
    }
}