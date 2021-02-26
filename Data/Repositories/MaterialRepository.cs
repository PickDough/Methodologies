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
        public void Add(Material material)
        {
            _db.Materials.Add(material);
            _db.SaveChanges();
        }

        public void Update(Material material)
        {
            _db.Materials.Update(material);
            _db.SaveChanges();
        }

        public Material Get(Guid id)
        {
            return _db.Materials
                .Include("MaterialType")
                .Include("MaterialUnit")
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Material> GetAll()
        {
            return _db.Materials
                .Include("MaterialType")
                .Include("MaterialUnit")
                .ToList();
        }

        public List<Material> GetMaterialsInOrderItem(Guid orderItemId)
        {
            OrderItem orderItem = _db.OrderItems
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialType)
                .Include(item => item.Frame)
                    .ThenInclude(frame => frame.Materials)
                    .ThenInclude(material => material.MaterialUnits)
                .FirstOrDefault(item => item.Id == orderItemId);
            return orderItem.Frame.Materials;
        }

        public void Delete(Guid id)
        {
            _db.Materials.Remove(_db.Materials.Find(id));
            _db.SaveChanges();
        }
    }
}