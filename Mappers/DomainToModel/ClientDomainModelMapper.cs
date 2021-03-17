using Domain;
using Model;

namespace Mappers.DomainToModel
{
    public class ClientDomainModelMapper
    {
        public static Client MapToDomain(ClientModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber
            };
        }

        public static ClientModel MapToModel(Client domain)
        {
            return new()
            {
                Id = domain.Id,
                Name = domain.Name,
                Surname = domain.Surname,
                PhoneNumber = domain.PhoneNumber
            };
        }
    }
}