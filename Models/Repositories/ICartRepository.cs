using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Repositories
{
    public interface ICartRepository
    {
        List<Cart> GetAll();
        Cart GetById(int id);
        void Delete(int id);
       // void Edit(Cart c);
        void Add(Cart c);
    }
}
