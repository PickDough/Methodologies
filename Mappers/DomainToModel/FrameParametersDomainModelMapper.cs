using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class FrameParametersDomainModelMapper
    {
        public static FrameParameters MapToDomain(FrameParametersModel model)
        {
            return new ()
            {
                Id = model.Id,
                Width = model.Width,
                Height = model.Height,
                DWidth = model.DWidth,
                DHeight = model.DHeight
            };
        }

        public static FrameParametersModel MapToModel(FrameParameters domain)
        {
            return new ()
            {
                Id = domain.Id,
                Width = domain.Width,
                Height = domain.Height,
                DWidth = domain.DWidth,
                DHeight = domain.DHeight
            };
        }
    }
}