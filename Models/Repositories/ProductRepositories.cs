
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;

namespace Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        EfDbContext context;
        public ProductRepository(EfDbContext context)
        {
            this.context = context;
        }
        

        public void Add(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void edit(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
