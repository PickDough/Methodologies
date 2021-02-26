using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IMaterialRepository
    {
        public void Add(Material material);
        public void Update(Material material);
        public Material Get(Guid id);
        public List<Material> GetAll();
        public List<Material> GetMaterialsInOrderItem(Guid orderItemId);
        public void Delete(Guid id);
    }
}