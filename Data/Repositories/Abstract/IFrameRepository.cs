using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IFrameRepository
    {
        public void Add(Frame frame);
        public void Update(Frame frame);
        public Frame Get(Guid id);
        public List<Frame> GetAll();
        public void Delete(Guid id);
    }
    
}