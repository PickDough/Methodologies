using System;
using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class OrderEntity: Entity
    {
        public Guid ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public List<OrderItemEntity> OrderItems { get; set; } 
    }
}