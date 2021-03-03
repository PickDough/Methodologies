using System.Linq;
using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class OrderEntityDomainMapper: IOrderEntityDomainMapper
    {
        private readonly IOrderItemEntityDomainMapper _orderItemEntityDomainMapper;

        public OrderEntityDomainMapper()
        {
            _orderItemEntityDomainMapper = new OrderItemEntityDomainMapper();
        }

        public OrderEntity MapToEntity(Order domain)
        {
            return new ()
            {
                Id = domain.Id,
                OrderItems = domain.OrderItems.Select(_orderItemEntityDomainMapper.MapToEntity).ToList()
            };
        }

        public Order MapToDomain(OrderEntity  entity)
        {
            return new ()
            {
                Id = entity.Id,
                OrderItems = entity.OrderItems.Select(_orderItemEntityDomainMapper.MapToDomain).ToList()
            };
        }
    }
}