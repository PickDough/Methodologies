using Entities;
using Model;

namespace Mappers
{
    public class MaterialTypeMapper: IMaterialTypeMapper
    {
        public MaterialType MapToEntity(MaterialTypeModel model)
        {
            return new MaterialType()
            {
                Id = model.Id,
                TypeName = model.TypeName
            };
        }

        public MaterialTypeModel MapToModel(MaterialType entity)
        {
            return new MaterialTypeModel()
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }
    }
}