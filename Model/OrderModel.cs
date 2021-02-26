using System.Collections.Generic;

namespace Model
{
    public class OrderModel: Model
    {
        public List<OrderItemModel> OrderItems { get; set; } 
    }
}