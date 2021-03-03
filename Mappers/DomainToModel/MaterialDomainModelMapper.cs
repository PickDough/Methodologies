using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class MaterialDomainModelMapper: IMaterialDomainModelMapper
    {
        private readonly IMaterialTypeDomainModelMapper _materialTypeDomainModelMapper;
        private readonly IMaterialUnitDomainModelnMapper _materialUnitDomainModelMapper;

        public MaterialDomainModelMapper()
        {
            _materialUnitDomainModelMapper = new MaterialUnitDomainModelMapper();
            _materialTypeDomainModelMapper = new MaterialTypeDomainModelMapper();
        }

        public Material MapToDomain(MaterialModel model)
        {
            return new ()
            {
                Id = model.Id,
                PricePerUnit = model.PricePerUnit,
                UnitsPerArea = model.UnitsPerArea,
                MaterialType = _materialTypeDomainModelMapper.MapToDomain(model.MaterialType),
                MaterialUnits = _materialUnitDomainModelMapper.MapToDomain(model.MaterialUnits)
            };
        }

        public MaterialModel MapToModel(Material domain)
        {
            return new ()
            {
                Id = domain.Id,
                PricePerUnit = domain.PricePerUnit,
                UnitsPerArea = domain.UnitsPerArea,
                MaterialType = _materialTypeDomainModelMapper.MapToModel(domain.MaterialType),
                MaterialUnits = _materialUnitDomainModelMapper.MapToModel(domain.MaterialUnits)
            };
        }
    }
}