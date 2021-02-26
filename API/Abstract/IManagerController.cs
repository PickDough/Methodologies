using System;
using System.Collections.Generic;
using Model;

namespace API.Abstract
{
    public interface IManagerController
    {
        public List<FrameModel> AvailableFrames { get;}
        public List<OrderModel> CreatedOrders { get;}
        public RequiredMaterialsModel CalculateRequiredMaterials(Guid orderId);
        public void AddNewOrder(OrderModel orderModel);
    }
}