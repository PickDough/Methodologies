using Domain;
using Entities;

namespace Mappers
{
    public class ClientEntityDomainMapper
    {
        public static ClientEntity MapToEntity(Client domain)
        {
            return new()
            {
                Name = domain.Name,
                Surname = domain.Surname,
                PhoneNumber = domain.PhoneNumber
            };
        }

        public static Client MapToDomain(ClientEntity entity)
        {
            return new()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                PhoneNumber = entity.PhoneNumber
            };
        }
    }
}