using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
  public interface IOrderDetailRepository
    {
        List<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        void Delete(int id);
        void Edit(OrderDetail p);
        void Add(OrderDetail p);
    }
}

