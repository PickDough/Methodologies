using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class FrameService: IFrameService
    {
        private readonly IFrameRepository _frameRepository;
        private readonly IFrameMapper _mapper;

        public FrameService()
        {
            _frameRepository = new FrameRepository();
            _mapper = new FrameMapper();
        }

        public List<FrameModel> GetAllFrames()
        {
            List<Frame> frames = _frameRepository.GetAll();
            return _frameRepository.GetAll().Select(_mapper.MapToModel).ToList();
        }
    }
}