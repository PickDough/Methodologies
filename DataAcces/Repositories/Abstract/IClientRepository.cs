using System;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IClientRepository: IRepository<ClientEntity, Guid>
    {
        public bool Exists(ClientEntity entity);
    }
}