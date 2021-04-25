using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IOrderRepository: IRepository<OrderEntity, Guid>
    {
        public OrderEntity GetComplex(Guid id);
        public IEnumerable<OrderEntity> GetAllComplex();
    }
}