using Entities;
using Model;

namespace Mappers
{
    public class MaterialMapper: IMaterialMapper
    {
        private readonly IMaterialTypeMapper _materialTypeMapper;
        private readonly IMaterialUnitMapper _materialUnitMapper;
        
        public MaterialMapper()
        {
            _materialTypeMapper = new MaterialTypeMapper();
            _materialUnitMapper = new MaterialUnitMapper();
        }
        public Material MapToEntity(MaterialModel model)
        {
            return new Material()
            {
                Id = model.Id,
                PricePerUnit = model.PricePerUnit,
                UnitsPerArea = model.UnitsPerArea,
                MaterialType = _materialTypeMapper.MapToEntity(model.MaterialType),
                MaterialUnits = _materialUnitMapper.MapToEntity(model.MaterialUnits)
            };
        }

        public MaterialModel MapToModel(Material entity)
        {
            return new MaterialModel()
            {
                Id = entity.Id,
                PricePerUnit = entity.PricePerUnit,
                UnitsPerArea = entity.UnitsPerArea,
                MaterialType = _materialTypeMapper.MapToModel(entity.MaterialType),
                MaterialUnits = _materialUnitMapper.MapToModel(entity.MaterialUnits)
            };
        }
    }
}