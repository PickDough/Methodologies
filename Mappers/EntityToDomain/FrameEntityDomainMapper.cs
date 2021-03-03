using System.Linq;
using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class FrameEntityDomainMapper: IFrameEntityDomainMapper
    {
        private readonly IFrameTypeParameterEntityDomainMapper _frameTypeEntityDomainMapper;
        
        public FrameEntityDomainMapper()
        {
            _frameTypeEntityDomainMapper = new FrameTypeEntityDomainMapper();
        }
        
        public FrameEntity MapToEntity(Frame domain)
        {
            return new ()
            {
                Id = domain.Id,
                Name = domain.Name,
                Info = domain.Info,
                Description = domain.Description,
                FrameType = _frameTypeEntityDomainMapper.MapToEntity(domain.FrameType)
            };
        }

        public Frame MapToDomain(FrameEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                Name = entity.Name,
                Info = entity.Info,
                FrameType = _frameTypeEntityDomainMapper.MapToDomain(entity.FrameType)
            };
        }
    }
}