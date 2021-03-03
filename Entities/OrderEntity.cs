using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class OrderEntity: Entity
    {
        public List<OrderItemEntity> OrderItems { get; set; } 
    }
}