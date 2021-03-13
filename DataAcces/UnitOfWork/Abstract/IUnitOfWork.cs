using System;
using Data.Repositories.Abstract;

namespace Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        public IFrameRepository FrameRepository{ get; }
        public IMaterialRepository MaterialRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IClientRepository ClientRepository { get; }
        public void Save();
    }
}