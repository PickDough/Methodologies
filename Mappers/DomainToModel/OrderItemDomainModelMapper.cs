using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class OrderItemDomainModelMapper: IOrderItemDomainModelMapper
    {
        private readonly IFrameDomainModelMapper _frameDomainModelMapper;
        private readonly IFrameParametersDomainModelMapper _frameParametersDomainModelMapper;

        public OrderItemDomainModelMapper()
        {
            _frameParametersDomainModelMapper = new FrameParametersDomainModelMapper();
            _frameDomainModelMapper = new FrameDomainModelMapper();
        }

        public OrderItem MapToDomain(OrderItemModel model)
        {
            return new ()
            {
                Id = model.Id,
                Frame = _frameDomainModelMapper.MapToDomain(model.Frame),
                FrameParameters = _frameParametersDomainModelMapper.MapToDomain(model.FrameParameters),
                Quantity = model.Quantity
            };
        }

        public OrderItemModel MapToModel(OrderItem domain)
        {
            return new ()
            {
                Id = domain.Id,
                Frame = _frameDomainModelMapper.MapToModel(domain.Frame),
                FrameParameters = _frameParametersDomainModelMapper.MapToModel(domain.FrameParameters),
                Quantity = domain.Quantity
            };
        }
    }
}