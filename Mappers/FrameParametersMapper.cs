using Entities;
using Model;

namespace Mappers
{
    public class FrameParametersMapper: IFrameParametersMapper
    {
        public FrameParameters MapToEntity(FrameParametersModel model)
        {
            FrameParameters frameParameters = new FrameParameters();
            frameParameters.Id = model.Id;
            frameParameters.Height = model.Height;
            frameParameters.Width = model.Width;
            frameParameters.DHeight = model.DHeight;
            frameParameters.DWidth = model.DWidth;
            return frameParameters;
        }

        public FrameParametersModel MapToModel(FrameParameters entity)
        {
            return new FrameParametersModel()
            {
                Id = entity.Id,
                Width = entity.Width,
                Height = entity.Height,
                DWidth = entity.DWidth,
                DHeight = entity.DHeight
            };
        }
    }
}