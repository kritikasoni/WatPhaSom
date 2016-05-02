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

        void Add(Product p);
        List<Product> GetAll();
        void Delete(int id);
        void edit(int id);
        void GetByID(int id);


    }
}
