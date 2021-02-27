using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class OrderRepository: IOrderRepository
    {
        private readonly FrameDataContext _db;

        public OrderRepository()
        {
            _db = new FrameDataContext();
        }
        public void Add(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public void Update(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }

        public Order Get(Guid id)
        {
            return _db.Orders
                .Include("OrderItems.FrameParameters")
                .Include("OrderItems.Frame")
                .FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return _db.Orders
                .Include("OrderItems.FrameParameters")
                .Include("OrderItems.Frame")
                .Include("OrderItems.Frame.FrameType")
                .ToList();
        }

        public void Delete(Guid id)
        {
            _db.Orders.Remove(_db.Orders.Find(id));
            _db.SaveChanges();
        }
    }
}