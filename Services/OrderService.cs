using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Entities;
using Mappers;
using Model;
using Services.Abstract;

namespace Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMapper _mapper;
        private readonly IMaterialService _materialService;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _mapper = new OrderMapper();
            _materialService = new MaterialService();
        }

        public void AddOrder(OrderModel order)
        {
            _orderRepository.Add(_mapper.MapToEntity(order));
        }

        public List<OrderModel> GetAllOrders()
        {
            return _orderRepository.GetAll().Select(_mapper.MapToModel).ToList();
        }

        public RequiredMaterialsModel GetRequiredMaterials(Guid orderId)
        {
            List <OrderItemModel> orderItems = _mapper
                .MapToModel(_orderRepository.Get(orderId))
                .OrderItems;
            return new RequiredMaterialsModel()
            {
                OrderId = orderId,
                RequiredMaterials = _materialService.CalculateMaterials(orderItems)
            };
        }
    }
}