using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository: GenericRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext) {}

        public bool Exists(ClientEntity entity)
        {
            return dbSet.Any(client =>  client.Name == entity.Name 
                                        && client.Surname == entity.Surname 
                                        && client.PhoneNumber == entity.PhoneNumber);
        }
    }
}