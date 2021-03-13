using System.Collections.Generic;

namespace Data.Repositories.Abstract
{
    public interface IRepository<TEntity, TKey>
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public TEntity Get(TKey key);
        public IEnumerable<TEntity> GetAll();
        public void Delete(TKey key);
    }
}