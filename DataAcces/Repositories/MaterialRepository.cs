using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MaterialRepository: GenericRepository<MaterialEntity>,  IMaterialRepository
    {
        public MaterialRepository(DbContext db) : base(db) {}


        public IEnumerable<MaterialEntity> GetAllComplex()
        {
            return dbSet
                .Include(material => material.MaterialType)
                .Include(material => material.MaterialUnits)
                .ToList();
        }

        public IEnumerable<MaterialEntity> GetMaterialsInOrderItem(Guid orderItemId)
        {
            OrderItemEntity orderItemEntity = db.Set<OrderItemEntity>()
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialType)
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialUnits)
                .FirstOrDefault(item => item.Id == orderItemId);
            
            return orderItemEntity.Frame.Materials;
        }
    }
}