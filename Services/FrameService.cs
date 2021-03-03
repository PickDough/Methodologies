using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Mappers;
using Mappers.DomainToModel;
using Model;
using Services.Abstract;

namespace Services
{
    public class FrameService: IFrameService
    {
        private readonly IFrameRepository _frameRepository;
        private readonly IFrameEntityDomainMapper _entityDomainMapper;
        private readonly IFrameDomainModelMapper _domainModelMapper;

        public FrameService()
        {
            _frameRepository = new FrameRepository();
            _entityDomainMapper = new FrameEntityDomainMapper();
            _domainModelMapper = new FrameDomainModelMapper();
        }

        public List<FrameModel> GetAllFrames()
        {
            return _frameRepository
                .GetAll()
                .Select(_entityDomainMapper.MapToDomain)
                .Select(_domainModelMapper.MapToModel)
                .ToList();
        }
    }
}