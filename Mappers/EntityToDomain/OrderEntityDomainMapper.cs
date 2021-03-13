using System.Linq;
using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class OrderEntityDomainMapper
    {
        public static OrderEntity MapToEntity(Order domain)
        {
            return new ()
            {
                Id = domain.Id,
                OrderItems = domain.OrderItems
                    .Select(OrderItemEntityDomainMapper.MapToEntity)
                    .ToList(),
                ClientId = domain.Client.Id
            };
        }

        public static Order MapToDomain(OrderEntity  entity)
        {
            return new ()
            {
                Id = entity.Id,
                OrderItems = entity.OrderItems
                    .Select(OrderItemEntityDomainMapper.MapToDomain)
                    .ToList(),
                Client = ClientEntityDomainMapper.MapToDomain(entity.Client)
            };
        }
    }
}