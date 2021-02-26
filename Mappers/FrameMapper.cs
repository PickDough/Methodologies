using System.Linq;
using Entities;
using Model;

namespace Mappers
{
    public class FrameMapper: IFrameMapper
    {
        private readonly IMaterialMapper _materialMapper;
        private readonly IFrameTypeParameterMapper _frameTypeMapper;
        
        public FrameMapper()
        {
            _materialMapper = new MaterialMapper();
            _frameTypeMapper = new FrameTypeMapper();
        }
        public Frame MapToEntity(FrameModel model)
        {
            return new Frame()
            {
                Id = model.Id,
                Name = model.Name,
                Info = model.Info,
                Description = model.Description,
                FrameType = _frameTypeMapper.MapToEntity(model.FrameType)
            };
        }

        public FrameModel MapToModel(Frame entity)
        {
            return new FrameModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Info = entity.Info,
                FrameType = _frameTypeMapper.MapToModel(entity.FrameType)
            };
        }
    }
}