using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class FrameTypeDomainModelMapper
    {
        public static FrameType MapToDomain(FrameTypeModel model)
        {
            return new ()
            {
                Id = model.Id,
                TypeName = model.TypeName
            };
        }

        public static FrameTypeModel MapToModel(FrameType domain)
        {
            return new ()
            {
                Id = domain.Id,
                TypeName = domain.TypeName
            };
        }
    }
}