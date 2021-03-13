using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class GenericRepository<TEntity>: IRepository<TEntity, Guid> where TEntity : class
    {
        protected readonly DbContext db;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual TEntity Get(Guid key)
        {
            return dbSet.Find(key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Delete(Guid key)
        {
            dbSet.Remove(Get(key));
        }
    }
}