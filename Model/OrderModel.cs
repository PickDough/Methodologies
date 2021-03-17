using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class OrderModel: Model
    {
        public ClientModel Client { get; set; }
        public ObservableCollection<OrderItemModel> OrderItems { get; set; } 
    }
}