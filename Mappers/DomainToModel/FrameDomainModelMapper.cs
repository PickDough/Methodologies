using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class FrameDomainModelMapper
    {
        public static Frame MapToDomain(FrameModel model)
        {
            return new ()
            {
                Id = model.Id,
                Name = model.Name,
                Info = model.Info,
                FrameType = FrameTypeDomainModelMapper.MapToDomain(model.FrameType)
            };
        }

        public static FrameModel MapToModel(Frame domain)
        {
            return new ()
            {
                Id = domain.Id,
                Name = domain.Name,
                Info = domain.Info,
                FrameType = FrameTypeDomainModelMapper.MapToModel(domain.FrameType)
            };
        }
    }
}