using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IMaterialRepository: IRepository<MaterialEntity, Guid>
    {
        public IEnumerable<MaterialEntity> GetMaterialsInOrderItem(Guid orderItemId);
        public IEnumerable<MaterialEntity> GetAllComplex();
    }
}