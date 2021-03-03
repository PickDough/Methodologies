using System.Linq;
using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class OrderDomainModelMapper: IOrderDomainModelMapper
    {
        private readonly IOrderItemDomainModelMapper _orderItemDomainModelMapper;

        public OrderDomainModelMapper()
        {
            _orderItemDomainModelMapper = new OrderItemDomainModelMapper();
        }

        public Order MapToDomain(OrderModel model)
        {
            
            return new ()
            {
                Id = model.Id,
                OrderItems = model.OrderItems.Select(_orderItemDomainModelMapper.MapToDomain).ToList()
            };
        }

        public OrderModel MapToModel(Order domain)
        {
            
            return new ()
            {
                Id = domain.Id,
                OrderItems = domain.OrderItems.Select(_orderItemDomainModelMapper.MapToModel).ToList()
            };
        }
    }
}