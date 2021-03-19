using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository: GenericRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext) {}

        public ClientEntity GetByInfo(ClientEntity entity)
        {
            return dbSet.FirstOrDefault(client =>  client.Name == entity.Name 
                                        && client.Surname == entity.Surname 
                                        && client.PhoneNumber == entity.PhoneNumber);
        }
    }
}