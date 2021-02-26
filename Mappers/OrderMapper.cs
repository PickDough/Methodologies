using System.Linq;
using Entities;
using Model;

namespace Mappers
{
    public class OrderMapper: IOrderMapper
    {
        private readonly IMapper<OrderItem, OrderItemModel> _orderItemMapper;

        public OrderMapper()
        {
            _orderItemMapper = new OrderItemMapper();
        }

        public Order MapToEntity(OrderModel model)
        {
            return new Order()
            {
                Id = model.Id,
                OrderItems = model.OrderItems.Select(_orderItemMapper.MapToEntity).ToList()
            };
        }

        public OrderModel MapToModel(Order  entity)
        {
            return new OrderModel()
            {
                Id = entity.Id,
                OrderItems = entity.OrderItems.Select(_orderItemMapper.MapToModel).ToList()
            };
        }
    }
}