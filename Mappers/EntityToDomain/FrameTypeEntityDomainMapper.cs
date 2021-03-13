using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class FrameTypeEntityDomainMapper
    {
        public static FrameTypeEntity MapToEntity(FrameType domain)
        {
            return new ()
            {
                Id = domain.Id,
                TypeName = domain.TypeName
            };
        }

        public static FrameType MapToDomain(FrameTypeEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }
    }
}