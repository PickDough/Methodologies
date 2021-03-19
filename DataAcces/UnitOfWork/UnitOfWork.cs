using System;
using Data.Repositories;
using Data.Repositories.Abstract;
using Data.UnitOfWork.Abstract;

namespace Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly FrameDataContext _db;
        private IFrameRepository _frameRepository;
        private IMaterialRepository _materialRepository;
        private IOrderRepository _orderRepository;
        private IClientRepository _clientRepository;

        public UnitOfWork(FrameDataContext db)
        {
            _db = db;
        }
        public IFrameRepository FrameRepository 
        {
            get { return _frameRepository ??= new FrameRepository(_db); }
        }

        public IMaterialRepository MaterialRepository
        {
            get { return _materialRepository ??= new MaterialRepository(_db);  }
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(_db); }
        }

        public IClientRepository ClientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_db); }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}