using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(string id);
        void Delete(string id);
        void Edit(Product p);
        void Add(Product p);
    }
}
