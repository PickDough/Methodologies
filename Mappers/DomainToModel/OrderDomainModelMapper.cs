using System.Linq;
using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class OrderDomainModelMapper
    {
        public static Order MapToDomain(OrderModel model)
        {
            
            return new ()
            {
                Id = model.Id,
                OrderItems = model.OrderItems
                    .Select(OrderItemDomainModelMapper.MapToDomain)
                    .ToList(),
                Client = ClientDomainModelMapper.MapToDomain(model.Client)
            };
        }

        public static OrderModel MapToModel(Order domain)
        {
            
            return new ()
            {
                Id = domain.Id,
                OrderItems = new (domain.OrderItems
                    .Select(OrderItemDomainModelMapper.MapToModel)
                    .ToList()),
                Client = ClientDomainModelMapper.MapToModel(domain.Client)
            };
        }
    }
}