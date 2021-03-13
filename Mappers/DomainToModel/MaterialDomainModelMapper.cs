using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class MaterialDomainModelMapper
    {
        public static Material MapToDomain(MaterialModel model)
        {
            return new ()
            {
                Id = model.Id,
                PricePerUnit = model.PricePerUnit,
                UnitsPerArea = model.UnitsPerArea,
                MaterialType = MaterialTypeDomainModelMapper.MapToDomain(model.MaterialType),
                MaterialUnits = MaterialUnitDomainModelMapper.MapToDomain(model.MaterialUnits)
            };
        }

        public static MaterialModel MapToModel(Material domain)
        {
            return new ()
            {
                Id = domain.Id,
                PricePerUnit = domain.PricePerUnit,
                UnitsPerArea = domain.UnitsPerArea,
                MaterialType = MaterialTypeDomainModelMapper.MapToModel(domain.MaterialType),
                MaterialUnits = MaterialUnitDomainModelMapper.MapToModel(domain.MaterialUnits)
            };
        }
    }
}