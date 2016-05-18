using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
  public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Delete(int id);
        void Edit(Order p);
        void Add(Order p);
    }
}
