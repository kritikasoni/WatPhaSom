using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;
using Models.Repositories;

namespace Web.Service
{
    public class OrderService
    {
        private IOrderDetailRepository _orderDetailRepository;
        private OrderProcessorRepository _orderProcessorRepository;

        public OrderService(IOrderDetailRepository orderDetailRepository,OrderProcessorRepository orderProcessorRepository
            )
        {
            _orderDetailRepository = orderDetailRepository;
            _orderProcessorRepository = orderProcessorRepository;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
             _orderDetailRepository.Add(orderDetail);
            
        }
        public List<Order> GetAll()
        {
            return _orderProcessorRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderProcessorRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _orderProcessorRepository.Delete(id);
        }

        public void Edit(Order o)
        {
            _orderProcessorRepository.Edit(o);
        }

        public void Add(OrderDetail od)
        {
            _orderDetailRepository.Add(od);
        }

    }
}