using System.Collections.Generic;
using Model;

namespace Services.Abstract
{
    public interface IFrameService
    {
        public List<FrameModel> GetAllFrames();
    }
}