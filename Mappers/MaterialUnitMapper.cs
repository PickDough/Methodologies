using Entities;
using Model;

namespace Mappers
{
    public class MaterialUnitMapper: IMaterialUnitMapper
    {
        public MaterialUnit MapToEntity(MaterialUnitModel model)
        {
            return new MaterialUnit()
            {
                Id = model.Id,
                UnitName = model.UnitName
            };
        }

        public MaterialUnitModel MapToModel(MaterialUnit entity)
        {
            return new MaterialUnitModel()
            {
                Id = entity.Id,
                UnitName = entity.UnitName
            };
        }
    }
}