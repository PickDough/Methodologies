using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class OrderItemEntityDomainMapper: IOrderItemEntityDomainMapper
    {
        private readonly IFrameParametersEntityDomainMapper _frameParametersEntityDomainMapper;
        private readonly IFrameEntityDomainMapper _frameEntityDomainMapper;

        public OrderItemEntityDomainMapper()
        {
            _frameParametersEntityDomainMapper = new FrameParametersEntityDomainMapper();
            _frameEntityDomainMapper = new FrameEntityDomainMapper();
        }

        public OrderItemEntity MapToEntity(OrderItem domain)
        {
            return new ()
            {
                Id = domain.Id,
                FrameId = domain.Frame.Id,
                FrameParameters = _frameParametersEntityDomainMapper.MapToEntity(domain.FrameParameters),
                Quantity = domain.Quantity
            };
        }

        public OrderItem MapToDomain(OrderItemEntity  entity)
        {
            return new ()
            {
                Id = entity.Id,
                Frame = _frameEntityDomainMapper.MapToDomain(entity.Frame),
                FrameParameters = _frameParametersEntityDomainMapper.MapToDomain(entity.FrameParameters),
                Quantity = entity.Quantity
            };
        }
    }
}