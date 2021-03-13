using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IOrderRepository: IRepository<OrderEntity, Guid>
    {
        public IEnumerable<OrderEntity> GetAllClientOrders(Guid clientId);
        public OrderEntity GetComplex(Guid id);
        public IEnumerable<OrderEntity> GetAllComplex();
    }
}