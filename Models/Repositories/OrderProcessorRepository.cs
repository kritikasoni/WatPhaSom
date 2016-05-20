using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;
using Models.Entities;
using Models.Repository;
using WatPhaSom.Models;

namespace Models.Repositories
{

        public class OrderProcessorRepository : IOrderProcessor
        {
            private EfDbContext _context;
            public OrderProcessorRepository(EfDbContext context)
            {
                _context = context;
            }

            public void ProcessOrder(Cart cart, Order order, string role)
            {
                double total = 0.0;
                if (role.Equals("Wholesale"))
                {

                    foreach (var o in order.OrderDetails)
                    {
                       total += o.Product.WholesalePrice*o.Quantity;
                    }
                }
                else
                {

                    foreach (var o in order.OrderDetails)
                    {
                        total += o.Product.RetailPrice * o.Quantity;
                    }
                }
                order.OrderDate = DateTime.Now;
                order.Experation = DateTime.Now;
                order.Total = total;
                order.OrderDetails = new List<OrderDetail>();
                _context.Entry(order).State = EntityState.Added;
                _context.SaveChanges();
            
            }

        public void Edit(Order o)
        {
            _context.Entry(o).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return _context.Orders.First(o => o.OrderId.Equals(id));
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
    }





