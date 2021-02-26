using Entities;
using Model;

namespace Mappers
{
    public class OrderItemMapper: IOrderItemMapper
    {
        private readonly IFrameParametersMapper _frameParametersMapper;
        private readonly IFrameMapper _frameMapper;

        public OrderItemMapper()
        {
            _frameParametersMapper = new FrameParametersMapper();
            _frameMapper = new FrameMapper();
        }

        public OrderItem MapToEntity(OrderItemModel model)
        {
            return new OrderItem()
            {
                Id = model.Id,
                FrameId = model.Frame.Id,
                FrameParameters = _frameParametersMapper.MapToEntity(model.FrameParameters),
                Quantity = model.Quantity
            };
        }

        public OrderItemModel MapToModel(OrderItem  entity)
        {
            return new OrderItemModel()
            {
                Id = entity.Id,
                Frame = _frameMapper.MapToModel(entity.Frame),
                FrameParameters = _frameParametersMapper.MapToModel(entity.FrameParameters),
                Quantity = entity.Quantity
            };
        }
    }
}