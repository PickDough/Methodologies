using Domain;

namespace Entities
{
    public class ClientEntity: Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}