﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Entities;
using SportStore.Repositories;
using SportStore.ViewModels.Order;
using SportStore.ViewModels.Product;

namespace SportStore.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepo;
        private IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public int AddOrder(AddOrderFormViewModel model)
        {
            Order newOrder = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Street = model.Street,
                City = model.City,
                Zip = model.Zip,
                Number = model.Number,
                OrderDate = DateTime.Now,
                CustomerID = model.CustomerID,
            };

            if (model.OrderItems != null)
            {
                foreach (var item in model.OrderItems)
                {
                    var product = _productRepo.GetById(item.ProductID);

                    OrderItem orderItem = new()
                    {
                        Quantity = item.Quantity,
                        UnitPrice = product.Price,
                        OrderID = item.OrderID,
                        ProductID = item.Id
                    };
                    newOrder.OrderItems.Add(orderItem);
                }
            }
            _orderRepo.Add(newOrder);
            _orderRepo.SaveChanges();

            return newOrder.Id;
        }

        public List<OrderItem> GetOrderItems(string customerId)
        {
            return _orderRepo.GetOrderItemWithOrder(customerId).ToList();
        }
    }
}
