using Entities;
using Model;

namespace Mappers
{
    public class FrameTypeMapper: IFrameTypeParameterMapper
    {
        public FrameType MapToEntity(FrameTypeModel model)
        {
            return new FrameType()
            {
                Id = model.Id,
                TypeName = model.TypeName
            };
        }

        public FrameTypeModel MapToModel(FrameType entity)
        {
            return new FrameTypeModel()
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }
    }
}