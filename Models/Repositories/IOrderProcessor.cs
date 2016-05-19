using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Repositories
{
   public  interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, OrderDetail orderDetails);
    }
}
