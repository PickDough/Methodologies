using System;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IClientRepository: IRepository<ClientEntity, Guid>
    {
        public ClientEntity GetByInfo(ClientEntity entity);
    }
}