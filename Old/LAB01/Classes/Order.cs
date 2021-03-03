using System;
using System.Collections.Generic;
using System.Linq;
using Methodology.LAB01.Classes;

namespace Methodology.LAB01
{
    public class Order: ContainerItem
    {
        public List<OrderItem> OrderItems { get; }

        public Order(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}