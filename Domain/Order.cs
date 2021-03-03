using System.Collections.Generic;

namespace Domain
{
    public class Order: Domain
    {
        public List<OrderItem> OrderItems { get; set; } 
    }
}