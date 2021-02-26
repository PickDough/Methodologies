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
        public void Add(Frame frame)
        {
            _db.Frames.Add(frame);
            _db.SaveChanges();
        }

        public void Update(Frame frame)
        {
            _db.Frames.Update(frame);
            _db.SaveChanges();
        }

        public Frame Get(Guid id)
        {
            return _db.Frames
                .Include("FrameType")
                .FirstOrDefault(f => f.Id == id);
        }

        public List<Frame> GetAll()
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