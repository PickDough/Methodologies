using System.Collections.Generic;

namespace Domain
{
    public class Order: Domain
    {
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } 
    }
}