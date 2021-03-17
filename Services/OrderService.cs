using System;
using System.Collections.Generic;
using System.Linq;
using Data.UnitOfWork.Abstract;
using Domain;
using Mappers;
using Mappers.DomainToModel;
using Model;
using Services.Abstract;

namespace Services
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMaterialService _materialService;

        public OrderService(IUnitOfWork uof, IMaterialService materialService)
        {
            _uof = uof;
            _materialService = materialService;
        }

        public void AddOrder(OrderModel order)
        {
            if (!_uof.ClientRepository.Exists(ClientEntityDomainMapper
                .MapToEntity(ClientDomainModelMapper
                    .MapToDomain(order.Client))))
            {
                _uof.ClientRepository.Add(ClientEntityDomainMapper
                    .MapToEntity(ClientDomainModelMapper
                        .MapToDomain(order.Client)));
            }
            _uof.OrderRepository
                .Add(OrderEntityDomainMapper
                    .MapToEntity(OrderDomainModelMapper
                        .MapToDomain(order)));
            _uof.Save();
        }

        public List<OrderModel> GetAllOrders()
        {
            var list = _uof.OrderRepository
                .GetAllComplex();
                
            var list2 = list.Select(OrderEntityDomainMapper.MapToDomain)
                .Select(OrderDomainModelMapper.MapToModel)
                .ToList();
            return list2;
        }

        public RequiredMaterialsModel GetRequiredMaterials(Guid orderId)
        {
            List <OrderItem> orderItems = OrderEntityDomainMapper
                .MapToDomain(_uof.OrderRepository.GetComplex(orderId))
                .OrderItems;
            return new RequiredMaterialsModel()
            {
                OrderId = orderId,
                RequiredMaterials = _materialService.CalculateMaterials(orderItems)
            };
        }
    }
}