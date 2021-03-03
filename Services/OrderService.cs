using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Domain;
using Entities;
using Mappers;
using Mappers.DomainToModel;
using Model;
using Services.Abstract;

namespace Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderEntityDomainMapper _entityDomainMapper;
        private readonly IMaterialService _materialService;
        private readonly IOrderDomainModelMapper _domainModelMapper;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _entityDomainMapper = new OrderEntityDomainMapper();
            _materialService = new MaterialService();
            _domainModelMapper = new OrderDomainModelMapper();
        }

        public void AddOrder(OrderModel order)
        {
            _orderRepository
                .Add(_entityDomainMapper
                    .MapToEntity(_domainModelMapper
                        .MapToDomain(order)));
        }

        public List<OrderModel> GetAllOrders()
        {
            return _orderRepository
                .GetAll()
                .Select(_entityDomainMapper.MapToDomain)
                .Select(_domainModelMapper.MapToModel)
                .ToList();
        }

        public RequiredMaterialsModel GetRequiredMaterials(Guid orderId)
        {
            List <OrderItem> orderItems = _entityDomainMapper
                .MapToDomain(_orderRepository.Get(orderId))
                .OrderItems;
            return new RequiredMaterialsModel()
            {
                OrderId = orderId,
                RequiredMaterials = _materialService.CalculateMaterials(orderItems)
            };
        }
    }
}