using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class MaterialEntityDomainMapper: IMaterialEntityDomainMapper
    {
        private readonly IMaterialTypeEntityDomainMapper _materialTypeEntityDomainMapper;
        private readonly IMaterialUnitEntityDomainMapper _materialUnitEntityDomainMapper;
        
        public MaterialEntityDomainMapper()
        {
            _materialTypeEntityDomainMapper = new MaterialTypeEntityDomainMapper();
            _materialUnitEntityDomainMapper = new MaterialUnitEntityDomainMapper();
        }
        public MaterialEntity MapToEntity(Material domain)
        {
            return new ()
            {
                Id = domain.Id,
                PricePerUnit = domain.PricePerUnit,
                UnitsPerArea = domain.UnitsPerArea,
                MaterialType = _materialTypeEntityDomainMapper.MapToEntity(domain.MaterialType),
                MaterialUnits = _materialUnitEntityDomainMapper.MapToEntity(domain.MaterialUnits)
            };
        }

        public Material MapToDomain(MaterialEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                PricePerUnit = entity.PricePerUnit,
                UnitsPerArea = entity.UnitsPerArea,
                MaterialType = _materialTypeEntityDomainMapper.MapToDomain(entity.MaterialType),
                MaterialUnits = _materialUnitEntityDomainMapper.MapToDomain(entity.MaterialUnits)
            };
        }
    }
}