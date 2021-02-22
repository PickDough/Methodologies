using System;
using System.Collections.Generic;
using System.Linq;

namespace Methodology.LAB01.Classes
{
    public class ManagerClient
    {
        private DataContext _db;
        public List<Frame> AvailableFrames => _db.Frames.GetAll();
        public List<Order> CreatedOrders => _db.Orders.GetAll();

        public void AddNewOrder(List<OrderItemView> orderItemViews)
        {
            List<OrderItem> orderItems = orderItemViews.Select(v =>
                new OrderItem(v.Frame, v.Quantity,
                    new FrameParameters(v.Width, v.dWidth, v.Height, v.dHeight))).ToList();
            Order order = new Order(orderItems);
            _db.Orders.Add(order);
        }

        public Dictionary<Material, float> CalculateMaterials(Guid orderId)
        {
            Order order = _db.Orders.Get(orderId);
            Dictionary<Material, float> materialsAmount = new Dictionary<Material, float>();
            foreach (var orderItem in order.OrderItems)
            {
                foreach (var material in orderItem.Product.Materials)
                {
                    if (materialsAmount.ContainsKey(material))
                        materialsAmount[material] += 
                            material.UnitsPerArea * orderItem.FrameParameters.Area * orderItem.Quantity;
                    else
                        materialsAmount[material] =
                            material.UnitsPerArea * orderItem.FrameParameters.Area * orderItem.Quantity;
                }
            }

            return materialsAmount;
        }
    }
}