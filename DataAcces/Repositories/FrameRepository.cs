using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FrameRepository: GenericRepository<FrameEntity>, IFrameRepository
    {
        public FrameRepository(DbContext db) : base(db) { }

        public FrameEntity GetComplex(Guid id)
        {
            return dbSet
                .Include(frame => frame.FrameType)
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FrameEntity> GetAllComplex()
        {
            return dbSet
                .Include(frame => frame.FrameType)
                .ToList();
        }
    }
}