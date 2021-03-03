using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class FrameDomainModelMapper: IFrameDomainModelMapper
    {
        private readonly IFrameTypeDomainModelMapper _frameTypeDomainModelMapper;

        public FrameDomainModelMapper()
        {
            _frameTypeDomainModelMapper = new FrameTypeDomainModelMapper();
        }

        public Frame MapToDomain(FrameModel model)
        {
            return new ()
            {
                Id = model.Id,
                Name = model.Name,
                Info = model.Info,
                FrameType =_frameTypeDomainModelMapper.MapToDomain(model.FrameType)
            };
        }

        public FrameModel MapToModel(Frame domain)
        {
            return new ()
            {
                Id = domain.Id,
                Name = domain.Name,
                Info = domain.Info,
                FrameType = _frameTypeDomainModelMapper.MapToModel(domain.FrameType)
            };
        }
    }
}