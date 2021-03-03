using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FrameRepository: IFrameRepository
    {
        private readonly FrameDataContext _db;

        public FrameRepository()
        {
            _db = new FrameDataContext();
        }
        public void Add(FrameEntity frameEntity)
        {
            _db.Frames.Add(frameEntity);
            _db.SaveChanges();
        }

        public void Update(FrameEntity frameEntity)
        {
            _db.Frames.Update(frameEntity);
            _db.SaveChanges();
        }

        public FrameEntity Get(Guid id)
        {
            return _db.Frames
                .Include("FrameType")
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FrameEntity> GetAll()
        {
            return _db.Frames
                .Include("FrameType")
                .ToList();
        }

        public void Delete(Guid id)
        {
            _db.Frames.Remove(_db.Frames.Find(id));
            _db.SaveChanges();
        }
    }
}