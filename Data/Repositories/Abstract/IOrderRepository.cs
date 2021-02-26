using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public void Update(Order order);
        public Order Get(Guid id);
        public List<Order> GetAll();
        public void Delete(Guid id);
    }
}