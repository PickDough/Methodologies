using System.Collections.Generic;
using System.Linq;
using Data.UnitOfWork.Abstract;
using Mappers;
using Mappers.DomainToModel;
using Model;
using Services.Abstract;

namespace Services
{
    public class FrameService: IFrameService
    {
        private readonly IUnitOfWork _uof;

        public FrameService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public List<FrameModel> GetAllFrames()
        {
            return _uof.FrameRepository
                .GetAllComplex()
                .Select(FrameEntityDomainMapper.MapToDomain)
                .Select(FrameDomainModelMapper.MapToModel)
                .ToList();
        }
    }
}