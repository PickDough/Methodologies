using Domain;
using Entities;
using Model;

namespace Mappers
{
    public class MaterialTypeEntityDomainMapper
    {
        public static MaterialTypeEntity MapToEntity(MaterialType domain)
        {
            return new ()
            {
                Id = domain.Id,
                TypeName = domain.TypeName
            };
        }

        public static MaterialType MapToDomain(MaterialTypeEntity entity)
        {
            return new ()
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }
    }
}