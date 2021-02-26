using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Entity: IEntity
    {
        [Key]
        public Guid Id { get; set; }
        
    }
}