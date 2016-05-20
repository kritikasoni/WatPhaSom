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

        public OrderService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
             _orderDetailRepository.Add(orderDetail);
            
        }
        
    }
}