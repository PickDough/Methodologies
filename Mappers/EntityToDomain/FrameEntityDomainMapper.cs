using System.Linq;
using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class FrameEntityDomainMapper
    {
        public static FrameEntity MapToEntity(Frame domain)
        {
            return new ()
            {
                Id = domain.Id,
                Name = domain.Name,
                Info = domain.Info,
                Description = domain.Description,
                FrameType = FrameTypeEntityDomainMapper.MapToEntity(domain.FrameType)
            };
        }

        public static Frame MapToDomain(FrameEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                Name = entity.Name,
                Info = entity.Info,
                FrameType = FrameTypeEntityDomainMapper.MapToDomain(entity.FrameType)
            };
        }
    }
}