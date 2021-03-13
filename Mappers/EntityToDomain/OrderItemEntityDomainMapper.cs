using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class OrderItemEntityDomainMapper
    {
        public static OrderItemEntity MapToEntity(OrderItem domain)
        {
            return new ()
            {
                Id = domain.Id,
                FrameId = domain.Frame.Id,
                FrameParameters = FrameParametersEntityDomainMapper
                    .MapToEntity(domain.FrameParameters),
                Quantity = domain.Quantity
            };
        }

        public static OrderItem MapToDomain(OrderItemEntity  entity)
        {
            return new ()
            {
                Id = entity.Id,
                Frame = FrameEntityDomainMapper.MapToDomain(entity.Frame),
                FrameParameters = FrameParametersEntityDomainMapper.MapToDomain(entity.FrameParameters),
                Quantity = entity.Quantity
            };
        }
    }
}