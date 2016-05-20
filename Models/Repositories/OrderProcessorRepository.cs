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
                order.Total = 0;

                if (role.Equals("Wholesale"))
                {

                    foreach (var o in order.OrderDetails)
                    {
                        order.Total += o.Product.WholesalePrice*o.Quantity;
                    }
                }
                else
                {

                foreach (var o in order.OrderDetails)
                {
                    order.Total += o.Product.RetailPrice * o.Quantity;
                }
            }
                order.OrderDate = DateTime.Now;
                order.Experation = DateTime.Now;
                _context.Entry(order).State = EntityState.Added;
                _context.SaveChanges();
            
            }

        }
    }


