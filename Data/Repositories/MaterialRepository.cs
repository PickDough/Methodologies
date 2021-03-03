using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MaterialRepository:  IMaterialRepository
    {
        private readonly FrameDataContext _db;

        public MaterialRepository()
        {
            _db = new FrameDataContext();
        }
        public void Add(MaterialEntity materialEntity)
        {
            _db.Materials.Add(materialEntity);
            _db.SaveChanges();
        }

        public void Update(MaterialEntity materialEntity)
        {
            _db.Materials.Update(materialEntity);
            _db.SaveChanges();
        }

        public MaterialEntity Get(Guid id)
        {
            return _db.Materials
                .Include("MaterialType")
                .Include("MaterialUnit")
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MaterialEntity> GetAll()
        {
            return _db.Materials
                .Include("MaterialType")
                .Include("MaterialUnit")
                .ToList();
        }

        public IEnumerable<MaterialEntity> GetMaterialsInOrderItem(Guid orderItemId)
        {
            OrderItemEntity orderItemEntity = _db.OrderItems
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialType)
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialUnits)
                .FirstOrDefault(item => item.Id == orderItemId);
            return orderItemEntity.Frame.Materials;
        }

        public void Delete(Guid id)
        {
            _db.Materials.Remove(_db.Materials.Find(id));
            _db.SaveChanges();
        }
    }
}