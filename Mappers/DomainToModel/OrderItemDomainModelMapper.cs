using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class OrderItemDomainModelMapper
    {
        public static OrderItem MapToDomain(OrderItemModel model)
        {
            return new ()
            {
                Id = model.Id,
                Frame = FrameDomainModelMapper.MapToDomain(model.Frame),
                FrameParameters = FrameParametersDomainModelMapper.MapToDomain(model.FrameParameters),
                Quantity = model.Quantity
            };
        }

        public static OrderItemModel MapToModel(OrderItem domain)
        {
            return new ()
            {
                Id = domain.Id,
                Frame = FrameDomainModelMapper.MapToModel(domain.Frame),
                FrameParameters = FrameParametersDomainModelMapper.MapToModel(domain.FrameParameters),
                Quantity = domain.Quantity
            };
        }
    }
}