using System;
using System.Collections.Generic;
using Model;

namespace Services.Abstract
{
    public interface IOrderService
    {
        public void AddOrder(OrderModel order);
        public List<OrderModel> GetAllOrders();
        public RequiredMaterialsModel GetRequiredMaterials(Guid orderId);
    }
}