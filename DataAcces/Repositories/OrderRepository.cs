using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class OrderRepository: GenericRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(DbContext db) : base(db) {}

        public IEnumerable<OrderEntity> GetAllClientOrders(Guid clientId)
        {
            return dbSet
                .Where(order => order.ClientId == clientId)
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.FrameParameters)
                        .Include(order => order.OrderItems)
                    .ThenInclude(item => item.Frame)
                        .ThenInclude(frame => frame.FrameType)
                .ToList();
        }

        public OrderEntity GetComplex(Guid id)
        {
            return dbSet
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.FrameParameters)
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.Frame)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<OrderEntity> GetAllComplex()
        {
            return dbSet
                .Include(order => order.Client)
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.FrameParameters)
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.Frame)
                        .ThenInclude(frame => frame.FrameType)
                .ToList();
        }
    }
}