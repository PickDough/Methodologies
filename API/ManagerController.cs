using System;
using System.Collections.Generic;
using API.Abstract;
using Model;
using Services;
using Services.Abstract;

namespace API
{
    public class ManagerController: IManagerController
    {
        private readonly IOrderService _orderService;
        private readonly IFrameService _frameService;

        public ManagerController(IOrderService orderService, IFrameService frameService)
        {
            _orderService = orderService;
            _frameService = frameService;
        }

        List<FrameModel> IManagerController.AvailableFrames => _frameService.GetAllFrames();

        List<OrderModel> IManagerController.CreatedOrders => _orderService.GetAllOrders();

        public RequiredMaterialsModel CalculateRequiredMaterials(Guid orderId)
        {
            return _orderService.GetRequiredMaterials(orderId);
        }

        public void AddNewOrder(OrderModel orderModel)
        {
            _orderService.AddOrder(orderModel);
        }
    }
}