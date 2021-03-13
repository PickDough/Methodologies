using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IFrameRepository: IRepository<FrameEntity, Guid>
    {
        public IEnumerable<FrameEntity> GetAllComplex();
        public FrameEntity GetComplex(Guid id);
    }
    
}