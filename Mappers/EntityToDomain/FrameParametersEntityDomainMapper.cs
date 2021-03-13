using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class FrameParametersEntityDomainMapper
    {
        public static FrameParametersEntity MapToEntity(FrameParameters domain)
        {
            FrameParametersEntity frameParametersEntity = new FrameParametersEntity();
            frameParametersEntity.Id = domain.Id;
            frameParametersEntity.Height = domain.Height;
            frameParametersEntity.Width = domain.Width;
            frameParametersEntity.DHeight = domain.DHeight;
            frameParametersEntity.DWidth = domain.DWidth;
            return frameParametersEntity;
        }

        public static FrameParameters MapToDomain(FrameParametersEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                Width = entity.Width,
                Height = entity.Height,
                DWidth = entity.DWidth,
                DHeight = entity.DHeight
            };
        }
    }
}