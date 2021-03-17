using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class OrderModel: Model
    {
        public OrderModel(): base() {}
        public ClientModel Client { get; set; }
        public ObservableCollection<OrderItemModel> OrderItems { get; set; }

        public override string ToString()
        {
            return $"Order #{Id.ToString().Substring(0, 5)} by {Client}";
        }
    }
}