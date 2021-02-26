using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class Order: Entity
    {
        public List<OrderItem> OrderItems { get; set; } 
    }
}