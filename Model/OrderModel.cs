using System.Collections.Generic;

namespace Model
{
    public class OrderModel: Model
    {
        public ClientModel Client { get; set; }
        public List<OrderItemModel> OrderItems { get; set; } 
    }
}